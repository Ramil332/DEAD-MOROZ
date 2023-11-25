using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Explosion : MonoBehaviour
{

    [SerializeField] private float _power = 10f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _upForce = 1f;
    [SerializeField] private int _damage = 100;
    [SerializeField] private Transform _vfxExplosion;

    private void FixedUpdate()
    {

        Invoke(nameof(Detonate), 1.5f);
        DestroyGranade(1.5f);

    }

    /* private void OnEnable()
     {
         this.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 1f, ForceMode.Impulse);
     }*/

    public void MoveBomb(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddRelativeForce(direction * 10f, ForceMode.Impulse);
    }
    private void Detonate()
    {
        SoundManager.PlaySound(SoundManager.Sound.Exploizion);
        Vector3 explositionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explositionPosition, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy") || collider.CompareTag("Crystal"))
            {
                IDamagable damagable = collider.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.Damage(_damage);
                }
            }

            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(_power, explositionPosition, _radius, _upForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Crystal"))
        {
            Detonate();
            DestroyGranade(0f);
        }
    }

    private void DestroyGranade(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnDestroy()
    {
        Instantiate(_vfxExplosion, transform.position, Quaternion.identity);
    }
}
