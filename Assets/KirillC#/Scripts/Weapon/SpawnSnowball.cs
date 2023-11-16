using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    [SerializeField] private GameObject _snowballPref;
    [SerializeField] private Transform _snowballSpawner;
    public void CreatBomb()
    {
        GameObject snowball = Instantiate(_snowballPref, _snowballSpawner.position, transform.rotation);
        //snowball.GetComponent<Snowball>().MoveBomb();
    }

}
