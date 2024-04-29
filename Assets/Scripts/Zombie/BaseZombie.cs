using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseZombie : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] float _health;

    [SerializeField] protected float _deathCost;

    public virtual void Init() 
    {
        _hpSlider.maxValue = _health;
    }
    protected virtual void Move() {}
    protected virtual void Attack() {}
    protected virtual void OnDead() {}

    void RemoveHp(float hp) 
    {
        _health -= hp;
        _hpSlider.value = _health;

        if (_health <= 0)
            OnDead();
    }
}
