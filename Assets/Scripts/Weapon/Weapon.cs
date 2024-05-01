using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _cartridges;
    [SerializeField] protected float _rechargeTime;

    [SerializeField] protected GameObject _cartridge;

    private bool _canAttack = true;
    private int _currentCartridges;

    public virtual void Init() { }
    public void Shoot() 
    {
        if (_canAttack == false)
            return;

        if (_currentCartridges > 0)
        {
            _currentCartridges--;
            OnAttack();
        }
        else
        {
            _canAttack = false;
            Invoke("Recharge", _rechargeTime);
        }
    }

    void Recharge()
    {
        _currentCartridges = _cartridges;
        _canAttack = true;
    }

    protected virtual void OnAttack() { }
}
