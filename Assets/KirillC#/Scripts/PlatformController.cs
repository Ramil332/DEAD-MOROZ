using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform _uperPosition;
    [SerializeField]private Transform _startPosition;


    [SerializeField] private float _speedPlatform = 1f;

    private Vector3 _nextPosition;

    private void Start()
    {
        _nextPosition = transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _nextPosition, _speedPlatform * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _nextPosition = _uperPosition.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _nextPosition = _startPosition.position;
    }
}
