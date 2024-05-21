using UnityEngine;
using TMPro;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _cartridges;
    [SerializeField] protected float _rechargeTime;
    [SerializeField] SliderTimer _timer;

    [SerializeField] protected GameObject _cartridge;

    [SerializeField] TextMeshProUGUI _cartridgeText;

    private bool _canAttack = true;
    private int _currentCartridges;
    private bool _isUnLimited;

    public void MakeUnlimited(bool isTrue)
    {
        _isUnLimited = isTrue;
    }

    public virtual void Init() 
    {
        _currentCartridges = _cartridges;
        UpdateCartridge();
        _timer.SetTime(_rechargeTime);
    }
    public bool Shoot() 
    {
        if (_canAttack == false)
            return false;

        if (_isUnLimited)
        {
            OnAttack();
            return true;
        }

        if (_currentCartridges > 0)
        {
            _currentCartridges--;
            UpdateCartridge();
            OnAttack();
            return true;
        }
        
        if (_currentCartridges <= 0)
        {
            _timer.gameObject.SetActive(true);
            _canAttack = false;
            Invoke("Recharge", _rechargeTime);
            return false;
        }

        return false;
    }

    void Recharge()
    {
        _currentCartridges = _cartridges;
        UpdateCartridge();
        _canAttack = true;
    }

    void UpdateCartridge()
    {
        _cartridgeText.text =
            _currentCartridges.ToString() + "/" + _cartridges.ToString();
    }

    protected virtual void OnAttack() { }
}
