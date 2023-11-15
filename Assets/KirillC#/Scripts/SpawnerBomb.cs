using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private GameObject _bombPref;
    [SerializeField] private Transform _bombSpawner;
    public void CreatBomb()
    {
        GameObject bomb = Instantiate(_bombPref, _bombSpawner.position, Quaternion.identity);
        bomb.GetComponent<Explosion>().MoveBomb(transform.forward);
    }
}
