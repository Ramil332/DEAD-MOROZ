using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
