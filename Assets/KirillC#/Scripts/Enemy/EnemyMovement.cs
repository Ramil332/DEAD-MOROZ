using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _attackDistance = 1f;
    [SerializeField] protected float _rotSpeed = .15f;

    [SerializeField] [Range(0, 10)] protected float _attackRate;

    protected float _attackTime;
    protected bool _isAttacking;

    protected Animator _enemyAnim;
    //  private Rigidbody _myBody;

    protected Transform _playerTarget;
    protected float _chasePlayerAfterAttack = 1f;

    protected float _currentAttackTime;
    [SerializeField] protected float _defaultAttackTime = 2f;

    protected bool _followPlayer = false;
    protected bool _attackPlayer = false;

    [SerializeField] protected float _fireDistance = 1f;
    protected bool _firePlayer = false;
    protected Vector3 _playerPos;

    protected NavMeshAgent _agent;

    protected float _deley = 0.5f;
    protected float _currentDeley = 0f;

    [SerializeField]private bool _santa = false;

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

    protected void FollowTarget()
    {
        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance)
        {

            transform.LookAt(_playerPos);

            _playerPos = _playerTarget.position;
            _playerPos.y = transform.position.y;
            //_agent.isStopped = false;
            _enemyAnim.SetBool("Movement", true);
            _agent.SetDestination(_playerTarget.position);

            if(_santa == true)
                SoundManager.PlaySound(SoundManager.Sound.SantaMove, transform.position);
            else
                SoundManager.PlaySound(SoundManager.Sound.EnemyMove, transform.position);

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
    

    protected void Attack()
    {
        if (_isAttacking)
        {
            _enemyAnim.SetTrigger("Attack");

            if (_santa == true)
                SoundManager.PlaySound(SoundManager.Sound.SantaAttack, transform.position);
            else
                SoundManager.PlaySound(SoundManager.Sound.EnemyAttack, transform.position);

            transform.LookAt(_playerPos);

            _playerPos = _playerTarget.position;
            _playerPos.y = transform.position.y;
            SoundManager.PlaySound(SoundManager.Sound.EnemyAttack, transform.position);
        }

       

    }

 
}
