using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : Weapon
{
    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
    }
    public override void Shoot()
    {
        if (Deley <= _currentTime)
        {
            Debug.Log("ShootBash Bash");
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            AnimatorPlayer.SetTrigger("Fire");
            _currentTime = 0;
        }
    }
}
