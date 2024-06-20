using UnityEngine;
using TMPro;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _cartridges;
    [SerializeField] protected float _rechargeTime;
    [SerializeField] protected GameObject _cartridge;

    [SerializeField] SliderTimer _timer;
    [SerializeField] TextMeshProUGUI _cartridgeText;

    [SerializeField] int[] _reload;
    [SerializeField] int[] _cartridgesUpd;

    private bool _canAttack = true;
    private int _currentCartridges;
    private bool _isUnLimited;

    public virtual void Init() 
    {
        LoadData();
        _currentCartridges = _cartridges;
        UpdateCartridge();
        _timer.SetTime(_rechargeTime);
    }
    public void MakeUnlimited(bool isTrue)
    {
        _isUnLimited = isTrue;
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

            if (_currentCartridges <= 0)
                CheckRechard();

            return true;
        }
        
        if (_currentCartridges <= 0)
        {
            CheckRechard();
            return false;
        }

        return false;
    }

    protected virtual void OnAttack() { }

    private void CheckRechard()
    {
        _timer.gameObject.SetActive(true);
        _canAttack = false;
        Invoke("Recharge", _rechargeTime);
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

    void LoadData()
    {
        _rechargeTime = _reload[YG.YandexGame.savesData.Pistol[(int)WeaponSettings.recharge]];
        _cartridges = _cartridgesUpd[YG.YandexGame.savesData.Pistol[(int)WeaponSettings.cartridge]];
    }
}
