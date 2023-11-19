using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackDistance = 1f;
    [SerializeField] private float _rotSpeed = .15f;

    [SerializeField] [Range(0, 10)] private float _attackRate;

    private float _attackTime;
    private bool _isAttacking;

    private Animator _enemyAnim;
    //  private Rigidbody _myBody;

    private Transform _playerTarget;
    private float _chasePlayerAfterAttack = 1f;

    private float _currentAttackTime;
    [SerializeField] private float _defaultAttackTime = 2f;

    private bool _followPlayer = false;
    private bool _attackPlayer = false;

    [SerializeField] private float _fireDistance = 1f;
    private bool _firePlayer = false;
    private Vector3 _playerPos;

    private NavMeshAgent _agent;

    private float _deley = 0.5f;
    private float _currentDeley = 0f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _enemyAnim = GetComponent<Animator>();
        //  _myBody = GetComponent<Rigidbody>();

        _playerTarget = GameObject.FindWithTag("Player").transform;

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.SetDestination(_playerTarget.position);


        _followPlayer = true;
        _currentAttackTime = _defaultAttackTime;
    }

    private void Update()
    {
        _currentDeley += Time.deltaTime;
        
        //if (GetComponent<EnemyHealth>().Died != true)
        //{

       


        FollowTarget();

        //}
        // Fire();
        UpdateAttacking(Time.time);

    }
    private void UpdateAttacking(float deltaTime)
    {
        float fireInterval = 1.0f / _attackRate;

        if (deltaTime > _attackTime)
        {
            _isAttacking = true;
            _attackTime = deltaTime + fireInterval;
        }
        else
        {
            _isAttacking = false;
        }
    }

    private void FollowTarget()
    {
      

        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance)
        {

            transform.LookAt(_playerPos);

            _playerPos = _playerTarget.position;
            _playerPos.y = transform.position.y;
            //_agent.isStopped = false;
            _enemyAnim.SetBool("Movement", true);
            _agent.SetDestination(_playerTarget.position);

        }
        else 
        {
          

            if (!_isAttacking)
            {
                _enemyAnim.SetBool("Movement", false);
            }
            
           /* _followPlayer = false;
            _attackPlayer = true;*/
            Attack();

        }
    }

    private void Attack()
    {
        if (_isAttacking)
        {
            _enemyAnim.SetTrigger("Attack");

            transform.LookAt(_playerPos);

            _playerPos = _playerTarget.position;
            _playerPos.y = transform.position.y;
            SoundManager.PlaySound(SoundManager.Sound.EnemyAttack, transform.position);
        }

       

    }

    private void Fire()
    {
        if (_deley <= _currentDeley)
        {
            if (!_firePlayer)
                return;

            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _defaultAttackTime)
            {
                _enemyAnim.SetTrigger("Fire");
                _currentAttackTime = 0f;

            }

            if (Vector3.Distance(transform.position, _playerTarget.position) < _attackDistance + _chasePlayerAfterAttack)
            {
                _firePlayer = false;
                _followPlayer = true;
            }
        }
    }
    public void StartMap()
    {
        _followPlayer = true;
    }
}
