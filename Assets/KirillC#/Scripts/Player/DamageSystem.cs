using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float _power = 20f;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _upForce = 1f;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 explositionPosition = transform.position;

        Debug.Log(other.gameObject.name);
        //if (other.TryGetComponent(out Enemy health_system))
        //    if (_enemy != health_system)
        // health_system.ApplayDamage(_damage);
        if (other.CompareTag("Enemy"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.Damage(_damage);
            }
        }

        if (other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<DestroerObject>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(_power, explositionPosition, _radius, _upForce, ForceMode.Impulse);
            if (other.gameObject.GetComponent<DestroerObject>())
                other.gameObject.GetComponent<DestroerObject>().ObjectDestroy();
        }
    }

}
