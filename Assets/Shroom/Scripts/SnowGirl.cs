using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGirl : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private Transform[] _gifts;
    [SerializeField] [Range(0, 10)] private float _throwGiftRate;
    private float _throwTime;
    private bool _isThrowing;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void UpdateThrowGift(float deltaTime)
    {
        float fireInterval = 1.0f / _throwGiftRate;

        if (deltaTime > _throwTime)
        {
            _isThrowing = true;
            _throwTime = deltaTime + fireInterval;
        }
        else
        {
            _isThrowing = false;
        }

    }

    private void HandleMeleeAttack()
    {
        if (_isThrowing)
        {
            _animator.SetTrigger("Cast");
            _throwTime = 0;

            _isThrowing = false;

        }


    }

    private void UpdateThrowing()
    {
        _throwTime += Time.deltaTime;

        if (_throwGiftRate <= _throwTime)
        {
            _isThrowing = true;
            SoundManager.PlaySound(SoundManager.Sound.SnowGirl);
        }

    }


    private void Update()
    {
      //  UpdateThrowGift(Time.time);
        UpdateThrowing();
        HandleMeleeAttack();

    }

    private void GiftEvent()
    {
        if (_gifts != null)
        {
            int i = Random.Range(0, _gifts.Length);
           Transform gift = Instantiate(_gifts[i], _throwPoint.position, _gifts[i].rotation);
           GiftThrow giftThrow = gift.GetComponent<GiftThrow>();
            giftThrow.SetDestination(Vector3.forward);
        }
    }

}
