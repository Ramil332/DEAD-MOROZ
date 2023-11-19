using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    [SerializeField] [Range (0, 100)] float _damageAmount;

    private PlayerController _playerController;

    

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent(out PlayerController health_system))
        //    if (_playerController != health_system)
        //        health_system.ApplayDamage(_damageAmount);             
        if (other.CompareTag("Player"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.Damage(_damageAmount);
            }
        }
    }
}
