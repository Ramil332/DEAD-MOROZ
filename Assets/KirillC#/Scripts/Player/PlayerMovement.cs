using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
   // [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    //[SerializeField] private float _sensitivity = 1f;

    private Transform _cameraTransform;
    private Vector2 _mousePositionY;
    private Rigidbody _playerRb;
    private Animator _animator;

    private PlayerController _playerController;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.transform;
        _playerController = GetComponent<PlayerController>();
    }

    //public void Move_performend(Vector2 moveVector)
    //{
    //    if (_playerController.IsDied != true)
    //    {
    //        /*Vector3 velocity = new Vector3(moveVector.x * _speed,
    //                                      _playerRb.velocity.y,
    //                                      moveVector.y * _speed);

    //        transform.Translate(velocity, Space.Self);*/
    //        _playerRb.MovePosition(_playerRb.transform.position + transform.forward * _speed * Time.deltaTime * _speed
    //            * moveVector.y + transform.right * _speed * Time.deltaTime * moveVector.x);
    //        //_playerRb.AddForce(new Vector3(moveVector.x, 0, moveVector.y) * _speed, ForceMode.VelocityChange);

    //        if (moveVector.x != 0 || moveVector.y != 0)
    //            _animator.SetBool("Movement", true);
    //        else
    //            _animator.SetBool("Movement", false);
    //    }
    //}

    //public void Rotation_performend(Vector2 rotationVector)
    //{
    //    if (_playerController.IsDied != true)
    //    {
    //       // transform.localRotation = Quaternion.Euler(0, Mathf.Atan2(rotationVector.x, rotationVector.y) * Mathf.Rad2Deg * _rotationSpeed, 0);

    //        //float targetAngle = Mathf.Atan2(-rotationVector.x, -rotationVector.y) * Mathf.Rad2Deg;

    //        Quaternion nowAngle = Quaternion.Euler(0f, _cameraTransform.eulerAngles.y, 0f);

    //        //Quaternion nowAngle = Quaternion.Euler(0f, targetAngle, 0f);
    //        transform.rotation = Quaternion.Lerp(transform.rotation, nowAngle, Time.deltaTime * _rotationSpeed);
    //    }

    //}
    public void PlayerRotation(Vector2 rotation)
    {
        float targetAngle = Mathf.Atan2(-rotation.x, -rotation.y);
        Quaternion nowAngle = Quaternion.Euler(0f, targetAngle, 0f);

        transform.rotation = Quaternion.Lerp(transform.rotation, nowAngle, Time.deltaTime * _rotationSpeed);

    }
    private void Update()
    {
      //  transform.localRotation = Quaternion.Euler(0, _mousePositionY.y, 0);
    }
}
