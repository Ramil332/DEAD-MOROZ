using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalController : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private GameObject[] _stones;
    [SerializeField] private GameObject _crystal;

    [SerializeField] private BossArenaController _arenaController;
    private GameObject _enemy;
    private void Update()
    {
        _enemy = GameObject.FindWithTag("Enemy");
        if (_enemy == null)
        {
            foreach (var _stone in _stones)
            {
                _stone.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "His Cosnulsya");
        foreach (var enemy in _enemys)
        {
            enemy.SetActive(true);
        }
        foreach (var collider in _stones)
        {
            collider.SetActive(true);
        }

        _arenaController.CristalDestroyer();
        Destroy(_crystal);
    }
}
