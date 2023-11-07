using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
            Destroy(gameObject);
    }
}
