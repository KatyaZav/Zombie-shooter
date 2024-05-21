using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseZombie : MonoBehaviour
{
    [SerializeField] Gradient _gradient;
    [SerializeField] SpriteRenderer[] _partsSprites;
    [SerializeField, Range(0.8f, 1)] float _size; 

    [Space(20)]

    [SerializeField] HPBar _hpSlider;
    [SerializeField] float _maxHealth;
    [SerializeField] int _damage = 1;

    [SerializeField] protected int _deathCost = 1;
    [SerializeField] protected float _speed = 1;

    bool _wasAttacked = false;
    float _health;

    public static Action<int, BaseZombie> ZombieKilledEvent;

    bool _isDead = false;

    public virtual void Init(Vector3 pos) 
    {
        ChangeColor();
        ChangeSize();
        gameObject.SetActive(true);

        _isDead = false;
        _health = _maxHealth;
        gameObject.transform.localPosition = pos;
        gameObject.transform.localScale = Vector3.zero;
        
        _hpSlider.Deactivate();
        _hpSlider.Init(_health);
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

        ZombieKilledEvent?.Invoke(_deathCost, this);
        gameObject.SetActive(false);
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

    private void ChangeColor()
    {
        var color = _gradient.Evaluate(UnityEngine.Random.Range(0f, 1f));

        foreach (var e in _partsSprites)
        {
            e.color = color;
        }
    }
    private void ChangeSize()
    {
        transform.localScale = new Vector3(1, UnityEngine.Random.Range(_size, 1), 1);

    }
}
