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
    [SerializeField] protected Animator AnimatorPlayer;
    [SerializeField] protected float Deley = 1f;

    


    public abstract void Shoot();
   

}
