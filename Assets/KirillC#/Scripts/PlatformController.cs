using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform _upperPosition;
    [SerializeField] private Transform _startPosition;

    [SerializeField] private float _speedPlatform = 1f;

    private Vector3 _nextPosition;
    private bool _isGoingUp, _isGoingDown;

    private void Start()
    {
        _nextPosition = transform.position;
    }
    private void Update()
    {
        if (_isGoingUp)
        {
            MoveUp();
        }

        if (_isGoingDown)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition.position, _speedPlatform * Time.deltaTime);
        }
    }

    private void MoveUp()
    {
        if (Vector3.Distance(transform.position, _upperPosition.position) < 0.01f)
        {
            Debug.Log("awgfe3tg");
            transform.position = Vector3.Lerp(transform.position, _upperPosition.position, 0 * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _upperPosition.position, _speedPlatform * Time.deltaTime);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isGoingUp = true;
            _isGoingDown = false;
            _nextPosition = _upperPosition.position;
        }
        if (other.CompareTag("LiftEndPoint"))
        {
            _isGoingUp = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isGoingDown = true;
            _isGoingUp = false;
            _nextPosition = _startPosition.position;
        }
    }
}
