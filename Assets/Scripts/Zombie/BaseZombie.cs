using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseZombie : MonoBehaviour
{
    [SerializeField] HPBar _hpSlider;
    [SerializeField] float _health;
    [SerializeField] int _damage = 1;

    [SerializeField] protected int _deathCost = 1;
    [SerializeField] protected float _speed = 1;

    bool _wasAttacked = false;

    public static Action<int> ZombieKilledEvent;

    bool _isDead = false;

    public virtual void Init() 
    {
        _hpSlider.Init(_health);
    }

    public void AddDamage(int count = 1)
    {
        _damage += count;
        Debug.Log(_damage);
    }

    public void ChangeSpeed(int pr)
    {
        _speed = _speed * (pr / 100f);
    }

    protected virtual void Move() 
    {
        transform.Translate(transform.forward * Time.deltaTime * _speed * -1);
    }

    public virtual void Attack(PlayerInventory inventory) 
    {
        if (_wasAttacked == true)
            return;

        _wasAttacked = true;
        inventory.Hit(_damage);
        Destroy(gameObject);
    }
    protected virtual void OnDead() 
    {
        ZombieKilledEvent?.Invoke(_deathCost);
        _hpSlider.Deactivate();
        _isDead = true;
    }

    private void FixedUpdate()
    {
        if (_isDead == true)
            return;

        Move();
    }

    protected void RemoveHp(float hp) 
    {
        _health -= hp;
        _hpSlider.UpdateSlider(_health);

        if (_health <= 0 && _isDead == false)
            OnDead();
    }
}
