using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class ControlPlayer : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private InputManager _inputManager;
    private Transform _cameraTransform;
    private PlayerController _playerController;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private float _rotationSpeed = 0.15f;
    [SerializeField] private float _granadeThrowRate = 5f;
    [SerializeField] private float _meleeAttackRate = 5f;
    [SerializeField] private Image _granadeImage;
    [SerializeField] private Image _bagImage;

    private float _granadeThrowTime;
    private float _meleeAttackTime;
    //private Vector2 _mouseLook;
    private Vector3 _rotationTarget;
    private Vector3 _target;

    private Animator _animator;

    private bool _isReloadGranade, _isMeleeAttack, _isBagSound, _isGranadeSound;

    private void Awake()
    {
        SoundManager.Initialize();
        _playerController = GetComponent<PlayerController>();
        _granadeThrowTime = _granadeThrowRate;
        _meleeAttackTime = _meleeAttackRate;
        _granadeImage.fillAmount = _granadeThrowTime / _granadeThrowRate;
        _bagImage.fillAmount = _meleeAttackTime / _meleeAttackRate;

    }
    private void Start()
    {
        //SoundManager.PlaySound(SoundManager.Sound.MainSound);

        _animator = GetComponentInChildren<Animator>();

        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.InputInstance;
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (_inputManager.IsActive)
        {
            HandleMovement();

            HandleRotation();

            UpdateThrowing();

            HandleShooting();

            HandleBomb();

            HandleMeleeAttack();

            WeponChange();

            UpdateMeleeAttack();

            HandleReload();
        }
    }

    private void WeponChange()
    {
        if (_inputManager.WeaponChangePressed())
        {
            GetComponent<ActiveWeapon>().ChangeWeapon(_inputManager.WeaponChange());
        }
    }

    private void HandleShooting()
    {
        if (_inputManager.Shoot())
        {
            //if (_playerController.CurrentWeapon != null)
            //{
            //    _playerController.CurrentWeapon.Shoot();

            //    _animator.SetTrigger("Fire");
            //}

            if (_playerController.WeaponNow != null)
            {
                _playerController.WeaponNow.Shoot(_shootPoint, _target);

            }

        }
    }

    private void HandleBomb()
    {
        if (_inputManager.BombThrow())
        {
            if (!_isReloadGranade)
            {
                _playerController.SpawnBomb();
                _granadeThrowTime = 0;

                _isReloadGranade = true;
                _isGranadeSound = true;

            }

        }
    }

    private void HandleMeleeAttack()
    {
        if (_inputManager.MeleeAttack())
        {
            if (_isMeleeAttack)
            {
                _playerController.MelleAttack();
                _meleeAttackTime = 0;

                _isMeleeAttack = false;
                _isBagSound = true;
            }


        }
    }

    private void HandleReload()
    {
        if (_inputManager.WeaponReaload())
        {
            if (_playerController.WeaponNow != null)
            {
                _playerController.WeaponNow.ReloadWeapon();
            }

        }
    }

    public void SetShootTrigger()
    {
        _animator.SetTrigger("Fire");

    }
    private void UpdateThrowing()
    {
        _granadeThrowTime += Time.deltaTime;

        if (_granadeThrowRate <= _granadeThrowTime)
        {
            _isReloadGranade = false;
            if (_isGranadeSound)
            {
                SoundManager.PlaySound(SoundManager.Sound.GranadeReload);
                _isGranadeSound = false;
            }
        }
        _granadeImage.fillAmount = _granadeThrowTime / _granadeThrowRate;

    }
    private void UpdateMeleeAttack()
    {
        _meleeAttackTime += Time.deltaTime;

        if (_meleeAttackRate <= _meleeAttackTime)
        {
            _isMeleeAttack = true;
            if (_isBagSound)
            {
                SoundManager.PlaySound(SoundManager.Sound.BagReload);
                _isBagSound = false;
            }

        }
        _bagImage.fillAmount = _meleeAttackTime / _meleeAttackRate;

    }

    private void HandleMovement()
    {

        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector3 movement = _inputManager.GetPlayerMovement();

        Vector3 move = new(movement.x, 0f, movement.y);

        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move.y = 0f;
        _ = _controller.Move(_playerSpeed * Time.deltaTime * move);

        if (movement.x != 0 || movement.y != 0)
        {
            _animator.SetBool("Movement", true);
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove);
        }

        else _animator.SetBool("Movement", false);


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
            _target = hit.point;
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
