using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    
    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;
    private PlayerMovement _playerMovement;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Fire.performed += NowFire;
    }

    private void FixedUpdate()
    {
               _playerMovement.Move_performend(_playerInputActions.Player.Move.ReadValue<Vector2>());

    }

    public void NowFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerController.CurrentWeapon.Shoot();
        }
    }
   
}
