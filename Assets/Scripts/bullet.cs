using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;

    void Start()
    {
        _rb.AddForce(Vector3.forward*_speed, ForceMode.VelocityChange);
    }
}
