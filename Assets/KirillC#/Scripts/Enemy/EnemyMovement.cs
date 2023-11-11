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

    private Animator _enemyAnim;
    private Rigidbody _myBody;
   [SerializeField] private Transform _playerTarget;
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
        _enemyAnim = GetComponent<Animator>();
        _myBody = GetComponent<Rigidbody>();

        _playerTarget = GameObject.FindWithTag("Player").transform;

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        
         _followPlayer = true;
        _currentAttackTime = _defaultAttackTime;
    }

    private void Update()
    {
        _currentDeley += Time.deltaTime;
        if (GetComponent<Enemy>().Died != true)
        {

            transform.LookAt(_playerPos);

            _playerPos = _playerTarget.position;
            _playerPos.y = transform.position.y;

            Attack();

            FollowTarget();
        }
       // Fire();
    }

    private void FixedUpdate()
    {
        
    }

    private void FollowTarget()
    {
        if (_deley <= _currentDeley)
        {
            if (!_followPlayer)
                return;

            if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance)
            {


                _myBody.velocity = transform.forward * _speed;
                _agent.destination = _playerTarget.position;


                if (_myBody.velocity.sqrMagnitude != 0)
                {
                    //_enemyAnim.SetBool("Movement", true);
                }
            }
            else if (Vector3.Distance(transform.position, _playerTarget.position) <= _attackDistance)
            {
                _myBody.velocity = Vector3.zero;
                // _enemyAnim.SetBool("Movement", false);

                _followPlayer = false;
                _attackPlayer = true;

            }

        }
       
    }

    private void Attack()
    {
        if (_deley <= _currentDeley)
        {
            if (!_attackPlayer /*|| GetComponent<HealthSystem>()._isDead == true*/)
                return;

            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _defaultAttackTime)
            {
                _enemyAnim.SetTrigger("Attack");
                _currentAttackTime = 0f;
            }

            if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance + _chasePlayerAfterAttack)
            {
                _attackPlayer = false;
                _followPlayer = true;
            }
        }
    }

    private void Fire()
    {
        if (_deley <= _currentDeley)
        {
            if (!_firePlayer /*|| GetComponent<HealthSystem>()._isDead == true*/)
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
