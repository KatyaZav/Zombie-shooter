using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseZombie : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] float _health;
    [SerializeField] int _damage = 1;

    [SerializeField] protected int _deathCost;
    [SerializeField] protected float _speed;

    public static Action<int> ZombieKilledEvent;

    public virtual void Init() 
    {
        _hpSlider.maxValue = _health;
    }
    protected virtual void Move() 
    {
        transform.Translate(transform.forward * Time.deltaTime * _speed * -1);
    }

    public virtual void Attack(PlayerInventory inventory) 
    {
        inventory.Hit(_damage);
        Destroy(gameObject);
    }
    protected virtual void OnDead() 
    {
        ZombieKilledEvent?.Invoke(_deathCost);
    }

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
