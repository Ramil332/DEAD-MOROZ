using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
   private Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        Invoke(nameof(EnableCollider), .2f);
        Destroy(gameObject, 3f);
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
    }
}
