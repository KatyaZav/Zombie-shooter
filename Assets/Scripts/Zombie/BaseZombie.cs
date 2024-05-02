 using UnityEngine;
using UnityEngine.UI;

public abstract class BaseZombie : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] float _health;

    [SerializeField] protected float _deathCost;
    [SerializeField] protected float _speed;

    public virtual void Init() 
    {
        _hpSlider.maxValue = _health;
    }
    protected virtual void Move() 
    {
        transform.Translate(transform.forward * Time.deltaTime * _speed * -1);
    }

    protected virtual void Attack() {}
    protected virtual void OnDead() {}

    private void FixedUpdate()
    {
        Move();
    }

    void RemoveHp(float hp) 
    {
        _health -= hp;
        _hpSlider.value = _health;

        if (_health <= 0)
            OnDead();
    }
}
