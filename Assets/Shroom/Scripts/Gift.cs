using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private Transform _pfGift;
    [SerializeField] private Transform _position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_pfGift != null)
            {
                Instantiate(_pfGift, _position.position, _pfGift.rotation);

            }
            Destroy(gameObject);

        }
    }
}
