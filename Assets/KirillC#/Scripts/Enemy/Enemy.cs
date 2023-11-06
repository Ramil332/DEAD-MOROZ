using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _health;
    private Animator _animator;

    private bool _died = false;

    public bool Died => _died;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    internal void ApplayDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _died = true;
            Debug.Log("Die");
            _animator.SetTrigger("Died");
            Destroy(gameObject, 5f);
        }

    }

   
}
