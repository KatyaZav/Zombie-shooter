using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseItems : MonoBehaviour
{
    [SerializeField] protected float _hp;
    [SerializeField] protected StandartZombie _zombie;

    private bool _isDestroyed = false;

    public void Activate()
    {
        OnInit();

        gameObject.SetActive(true);
    } 

    protected virtual void OnInit() { }

    protected virtual void OnDestroyd() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _hp -= 1;

            if (_hp <= 0 && _isDestroyed == false)
            {
                OnDestroyd();
                _isDestroyed = true;
            }
        }
    }
}
