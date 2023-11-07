using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _power = 10f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _upForce = 1f;
    [SerializeField] private int _damage = 100;


    private void FixedUpdate()
    {
        if(_bomb == enabled)
        {
            Invoke("Detonate", 5f);
            Destroy(gameObject, 5f);
        }
    }

    private void Detonate()
    {

        Vector3 explositionPosition = _bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explositionPosition, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<Enemy>())
                collider.gameObject.GetComponent<Enemy>().ApplayDamage(_damage);

            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(_power, explositionPosition, _radius, _upForce, ForceMode.Impulse);
        }
    }
}
