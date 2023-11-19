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
            SoundManager.PlaySound(SoundManager.Sound.ShootPistol, transform.position);
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            AnimatorPlayer.SetTrigger("Fire");
            _currentTime = 0;
        }
    }
}
