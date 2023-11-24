using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    [SerializeField] [Range(0, 100)] private int _damage;
    [SerializeField] [Range(0, 200)] private float _power = 20f;
    [SerializeField] [Range(0, 100)] private float _radius = 1f;
    [SerializeField] [Range(0, 100)] private float _upForce = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 explositionPosition = transform.position;

        //if (other.TryGetComponent(out Enemy health_system))
        //    if (_enemy != health_system)
        // health_system.ApplayDamage(_damage);
        if (other.CompareTag("Enemy") || other.CompareTag("Crystal"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.Damage(_damage);
            }
        }

        //if (other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<DestroerObject>())
        //{
        //    Rigidbody rb = other.GetComponent<Rigidbody>();
        //    if (rb != null)
        //        rb.AddExplosionForce(_power, explositionPosition, _radius, _upForce, ForceMode.Impulse);
        //    if (other.gameObject.GetComponent<DestroerObject>())
        //        other.gameObject.GetComponent<DestroerObject>().ObjectDestroy();
        //}
    }

}
