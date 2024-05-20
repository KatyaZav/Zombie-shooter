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

    public static Action<int, BaseZombie> ZombieKilledEvent;

    bool _isDead = false;

    public virtual void Init(Vector3 pos) 
    {
        _hpSlider.Init(_health);
        gameObject.SetActive(true);
        gameObject.transform.localPosition = pos;
        gameObject.transform.localScale = Vector3.zero;
    }

    public void AddDamage(int count = 1)
    {
        _damage += count;
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
        ZombieKilledEvent?.Invoke(_deathCost, this);
        _hpSlider.Deactivate();
        _isDead = true;
        gameObject.SetActive(false);
        gameObject.transform.localPosition = Vector3.zero;
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
