using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    [SerializeField] private int _damage;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.TryGetComponent(out Enemy health_system))
            if (_enemy != health_system)
                health_system.ApplayDamage(_damage);
    }

}
