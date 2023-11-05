using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerdel : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject player;
    private Vector3 cameraOffset = new Vector3(5,11,11);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
