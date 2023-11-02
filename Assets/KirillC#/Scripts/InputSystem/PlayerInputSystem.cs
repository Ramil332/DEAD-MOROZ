using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;

    private Rigidbody _playerRb;
    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Move.performed += Move_performend;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _playerRb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * _speed, ForceMode.Force);
    }

    private void Move_performend(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;
        _playerRb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }
}
