using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField] private float _force = 10f;

    private Transform _playerTransform;
    private void OnEnable()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _force * Time.deltaTime, Space.Self);
        Destroy(gameObject, 3f);
    }
    public void MoveSnable()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, _playerTransform.position.z) * -_force, ForceMode.Impulse);
    }
}
