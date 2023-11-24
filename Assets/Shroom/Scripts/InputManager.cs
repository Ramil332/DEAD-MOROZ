using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    private  PlayerInputActions _inputPlayer;
    private static InputManager _inputInstance;
    [SerializeField] private Texture2D _cursorTexture;

    private bool _isActive = true;
    public static InputManager InputInstance
    {
        get
        {
            return _inputInstance;
        }
    }
    private void Awake()
    {
        if (_inputInstance != null && _inputInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _inputInstance = this;
        }
        _inputPlayer = new PlayerInputActions();

        //Cursor.visible = false;
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        _inputPlayer.Enable();
    }

    private void OnDisable()
    {
        _inputPlayer.Disable();
    }

    public bool IsActive => _isActive;
    public void InputDisable()
    {
        //_inputPlayer.Disable();
        _isActive = false;


    }
    public void InputEnable()
    {
      //  _inputPlayer.Enable();
        _isActive = true;

    }
    public Vector2 GetPlayerMovement()
    {
        return _inputPlayer.Player.Move.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return _inputPlayer.Player.Jump.triggered;
    }

    public Vector2 GetMouseDelta()
    {
        return _inputPlayer.Player.MouseLook.ReadValue<Vector2>();
    }

    public bool Shoot()
    {
        return _inputPlayer.Player.Fire.IsPressed();
    }

    public Vector2 GetMousePosition()
    {
        return _inputPlayer.Player.FollowMouse.ReadValue<Vector2>();
    }

    public bool MeleeAttack()
    {
        return _inputPlayer.Player.MeleeAttack.triggered;
    }

    public bool BombThrow()
    {
        return _inputPlayer.Player.SpawnBomb.triggered;
    }

    public bool Pause()
    {
        return _inputPlayer.Player.Pause.triggered;
    }

    public int WeaponChange()
    {
        return (int)_inputPlayer.Player.WeaponChange.ReadValue<float>();
    }

    public bool WeaponChangePressed()
    {
        return _inputPlayer.Player.WeaponChange.triggered;
    }

}
