using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArena : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject[] _stones;

    //private bool _arenaOpen = false;

    private GameObject _enemy;

    //private void Update()
    //{
    //    _enemy = GameObject.FindWithTag("Enemy");
    //    if(_enemy == null && _spawner.GetComponent<Spawner>().CurrentEnemys.Count == _spawner.GetComponent<Spawner>().MaxEnemy)
    //    {
    //        foreach (var _stone in _stones)
    //        {
    //            _stone.SetActive(false);
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _spawner.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;

            foreach (var _stone in _stones)
            {
                _stone.SetActive(true);
            }
        }
    }
}
