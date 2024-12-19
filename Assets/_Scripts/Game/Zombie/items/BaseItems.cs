using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseItems : MonoBehaviour, IDamageble
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
        _zombie.AddPoint();
        OnInit();

        gameObject.SetActive(true);
    } 

    protected virtual void OnInit() { }
    protected virtual void OnDestroyed() { }
    protected virtual void OnDamaged() { }

    public void TakeDamage(float damage)
    {
        _hp -= damage;

        if (_hp <= 0 && _isDestroyed == false)
        {
            OnDestroyed();
            _isDestroyed = true;
        }
        else
        {
            OnDamaged();
        }
    }
}
