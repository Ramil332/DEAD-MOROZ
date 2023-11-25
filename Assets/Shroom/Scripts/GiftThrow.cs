using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftThrow : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private float _speed;
    [SerializeField] [Range(0, 100)] private float _lifeTime;

    private Vector3 _destintaion;
    private bool _isShoot;
    private void Update()
    {
        if (_isShoot)
        {
            var step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _destintaion, step);
        }
        // transform.Translate(_destintaion * _speed * Time.deltaTime, Space.Self);
        Destroy(gameObject, _lifeTime);
    }

    public void SetDestination(Vector3 targetDestination)
    {
        _destintaion = targetDestination;
        _isShoot = true;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    Destroy(gameObject);
    //}
}
