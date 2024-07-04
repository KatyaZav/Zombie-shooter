using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool wasGetted;

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _sprite;

    void Start()
    {
        _rb.AddForce(Vector3.forward*_speed*2, ForceMode.VelocityChange);
    }

    private void OnDestroy()
    {
        if (transform.position.z <= 29)
        {
            var o = Instantiate(_sprite, transform.position, transform.rotation);
            Destroy(o);
        }
    }
}
