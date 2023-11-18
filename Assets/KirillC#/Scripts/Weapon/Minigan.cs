using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigan : Weapon
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
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            AnimatorPlayer.SetTrigger("Fire");
            _currentTime = 0;
        }
    }
}
