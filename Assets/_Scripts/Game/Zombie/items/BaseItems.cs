using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseItems : MonoBehaviour
{
    [SerializeField] protected float _hp;
    [SerializeField, Range(0,10)] protected float _probability;
    [SerializeField] protected StandartZombie _zombie;

    private bool _isDestroyed = false;

    public bool CheckProbability(float kof = 1)
    {
        var rnd = Random.Range(0, 100);

        return rnd <= _probability * kof;
    }
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
