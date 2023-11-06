using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private PlayerController _target;

    public event UnityAction<Enemy> Dying;

    public int Reward => _reward;
    public PlayerController Target => _target;

    public void Init(PlayerController target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }

   /* public Player GetPlayer()
    {
        return _target;
    }*/ 
}
