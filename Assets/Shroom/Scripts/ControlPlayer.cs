using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControlPlayer : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private InputManager _inputManager;
    private Transform _cameraTransform;
    private PlayerController _playerController;

    [SerializeField] private Transform _gun;

    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private float _rotationSpeed = 0.15f;
    [SerializeField] private float _granadeThrowRate = 5f;

    private float _granadeThrowTime;
    //private Vector2 _mouseLook;
    private Vector3 _rotationTarget;

    private Animator _animator;

    private bool _isReloadGranade;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();

    }
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.InputInstance;
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        HandleMovement();

        HandleRotation();

        UpdateThrowing();

        if (_inputManager.Shoot())
        {
            if (_playerController.CurrentWeapon != null)
                _playerController.CurrentWeapon.Shoot();

            if (_playerController.WeaponNow != null) _playerController.WeaponNow.Shoot();
        }

        if (_inputManager.MeleeAttack())
        {
            _playerController.MelleAttack();
        }

        if (_inputManager.BombThrow())
        {
            if (!_isReloadGranade)
            {
                _playerController.SpawnBomb();
                _isReloadGranade = true;
            }

        }
    }
    private void UpdateThrowing()
    {
        _granadeThrowTime += Time.deltaTime;

        if (_granadeThrowRate <= _granadeThrowTime)
        {
            _isReloadGranade = false;
            _granadeThrowTime = 0;
        }

    }

    private void HandleMovement()
    {
        
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector3 movement = _inputManager.GetPlayerMovement();

        if (movement.x != 0 || movement.y != 0) { _animator.SetBool("Movement", true); SoundManager.PlaySound(SoundManager.Sound.PlayerMove, transform.position); }

        else _animator.SetBool("Movement", false);

        Vector3 move = new(movement.x, 0f, movement.y);

        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move.y = 0f;
        _ = _controller.Move(_playerSpeed * Time.deltaTime * move);

        //if (_inputManager.PlayerJumpedThisFrame() && _groundedPlayer)
        //{
        //    _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        //}

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    private void HandleRotation()
    {

        Ray ray = Camera.main.ScreenPointToRay(_inputManager.GetMousePosition());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _rotationTarget = hit.point;
        }

        var lookPos = _rotationTarget - transform.position;
        lookPos.y = 0;

        var rotation = Quaternion.LookRotation(lookPos);

        Vector3 aimDir = new Vector3(_rotationTarget.x, 0f, _rotationTarget.z);
        if (aimDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed);
        }
    }
}
