using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected Transform ShootPoint;

    [SerializeField] protected Bullet Bullet;

    public abstract void Shoot();
   

}
