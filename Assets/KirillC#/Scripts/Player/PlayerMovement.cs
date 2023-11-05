using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sensitivity = 1f;

    private Vector2 _mousePositionY;
    private Rigidbody _playerRb;


    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    public void Move_performend(Vector2 moveVector)
    {
        _playerRb.AddForce(new Vector3(moveVector.x, 0, moveVector.y) * _speed, ForceMode.Force);
    }

    private void Update()
    {
        _mousePositionY.y += Input.GetAxis("Mouse X") * _sensitivity;

        transform.localRotation = Quaternion.Euler(0, _mousePositionY.y, 0);
    }
}
