    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroerObject : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;
    public void ObjectDestroy()
    {
        _spawner.SetActive(true);
        Destroy(gameObject, 2f);
    }
}
