using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/WeaponStats", order = 1)]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField] public string WeaponName { get; private set; }
    [field: SerializeField] public Bullet Bullet { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; } = 1f;

    public Animator AnimatorPlayer { get; private set; }

    private void OnEnable()
    {
        AnimatorPlayer = GameObject.Find("Player").GetComponentInChildren<Animator>();
    }
}
