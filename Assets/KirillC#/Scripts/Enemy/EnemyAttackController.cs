using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    [SerializeField] int _damageAmount;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.TryGetComponent(out PlayerController health_system))
            if (_playerController != health_system)
                health_system.ApplayDamage(_damageAmount);             
    }
}
