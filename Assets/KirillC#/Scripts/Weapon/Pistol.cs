using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        Debug.Log("ShootBash Bash");
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
    }
}
