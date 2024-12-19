using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool wasGetted;

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _sprite;
    [SerializeField] float _destroyTime = 1;

    void Start()
    {
        _rb.AddForce(Vector3.forward*_speed*2, ForceMode.VelocityChange);
    }

    private void OnDestroed(Transform enemy)
    {
        if (transform.position.z <= 29)
        {
            var o = Instantiate(_sprite, transform.position, transform.rotation, enemy.parent);
            Destroy(o, _destroyTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageble damagable = other.GetComponent<IDamageble>();

        if (damagable != null)
        {
            damagable.TakeDamage(PlayerInventory.Damage);
            OnDestroed(other.transform);
            Destroy(gameObject);
        }
    }
}
