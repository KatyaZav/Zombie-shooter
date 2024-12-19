using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool wasGetted;

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _sprite;
    [SerializeField] float _destroyTime = 1;

    bool _wasDestroyed;

    void Start()
    {
        _wasDestroyed = false;
        _rb.AddForce(Vector3.forward*_speed*2, ForceMode.VelocityChange);
    }

    private void OnDestroed(Transform enemy)
    {
        if (transform.position.z <= 29)
        {
            var o = Instantiate(_sprite, transform.position, transform.rotation, enemy);
            Destroy(o, _destroyTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_wasDestroyed == true)
            return;

        IDamageble damagable = other.GetComponent<IDamageble>();

        if (damagable != null)
        {
            _wasDestroyed = true;

            damagable.TakeDamage(PlayerInventory.Damage);

            var enemyBase = other.GetComponentInParent<BaseZombie>();

            OnDestroed(enemyBase == null ? other.transform : enemyBase.transform);
            Destroy(gameObject);
        }
    }
}
