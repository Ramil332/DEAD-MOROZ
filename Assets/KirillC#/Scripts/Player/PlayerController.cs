using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
   // [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private GameObject _bombPref;
    [SerializeField] private GameObject _shotGunPanel;
    [SerializeField] private GameObject _miniGunPanel;
    [SerializeField] private TMP_Text _miniGunBulletsText;
    [SerializeField] private TMP_Text _miniGunTotalAmountBulletsText;
    [SerializeField] private TMP_Text _shotGunBulletsText;
    [SerializeField] private TMP_Text _shotGunTotalAmountBulletsText;
    [SerializeField] private float _bombForce = 20f;
    [SerializeField] private Transform _bombPosition;
    private Weapon _curentWeapon;
 //   private int _currentHealth;
    private Animator _animator;
   // private bool _isDied = false;
    public Weapon CurrentWeapon => _curentWeapon;

    private WeaponVar _weaponVar;

    public WeaponVar WeaponNow => _weaponVar;
   // public bool IsDied => _isDied;

    private void Start()
    {
        _miniGunPanel.SetActive(false);
        _shotGunPanel.SetActive(false);
        _animator = GetComponentInChildren<Animator>();
        if(_weapons.Count >0)
        _curentWeapon = _weapons[0];
      //  _currentHealth = _health;
    }

    public void SetCurrentWeapon(Weapon currentWeapon)
    {
        _curentWeapon = currentWeapon;
    }

    public void SetActiveWeapon(Transform weaponVar)
    {
        _weaponVar = weaponVar.GetComponent<WeaponVar>();
        _weaponVar.SetCurrentWeapon();
        _animator.SetLayerWeight(1, 1);
        //switch (_weaponVar.WeaponTypeC)
        //{
        //    case WeaponVar.WeaponType.minigun:

        //        _miniGunPanel.SetActive(true);
        //        _shotGunPanel.SetActive(false);

        //        _miniGunBulletsText.SetText(_weaponVar.BulletsInMagazine.ToString());
        //        break;

        //    case WeaponVar.WeaponType.shotgun:

        //        _shotGunPanel.SetActive(true);
        //        _miniGunPanel.SetActive(false);

        //        _shotGunBulletsText.SetText(_weaponVar.BulletsInMagazine.ToString());
        //        break;


        //}
    }

    public void MelleAttack()
    {
        _animator.SetTrigger("MelleAttack");
        SoundManager.PlaySound(SoundManager.Sound.MelleAttack, transform.position);
    }
    public void SpawnBomb()
    {
        _animator.SetTrigger("TrowGranade");
       
    }
    private void Update()
    {
        if (_weaponVar != null)
        {
            switch (_weaponVar.WeaponTypeC)
            {
                case WeaponVar.WeaponType.minigun:

                    _miniGunPanel.SetActive(true);
                    _shotGunPanel.SetActive(false);

                    _miniGunBulletsText.SetText(_weaponVar.BulletsInMagazine.ToString());
                    _miniGunTotalAmountBulletsText.SetText(_weaponVar.BulletsTotalAmount.ToString());
                    break;

                case WeaponVar.WeaponType.shotgun:

                    _shotGunPanel.SetActive(true);
                    _miniGunPanel.SetActive(false);

                    _shotGunBulletsText.SetText(_weaponVar.BulletsInMagazine.ToString());
                    _shotGunTotalAmountBulletsText.SetText(_weaponVar.BulletsTotalAmount.ToString());
                    break;
            }

        }
    }
}
