using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    private  PlayerInputActions _inputPlayer;
    private static InputManager _inputInstance;

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

        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _inputPlayer.Enable();
    }

    private void OnDisable()
    {
        _inputPlayer.Disable();
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
        return _inputPlayer.Player.Fire.triggered;
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
}
