using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject _hpSlider;

    float _maxHealth;
    float _sliderMax;

    bool _isInit = false;
    
    public void Deactivate()
    {
        _hpSlider.SetActive(false);
    }

    public void Init(float health)
    {
        _hpSlider.SetActive(true);

        _sliderMax = 0.1f;

        _maxHealth = health;
    }

    public void UpdateSlider(float health)
    {
        //if (_hpSlider.activeSelf == false)

        if (health <= 0)
        {
            _hpSlider.transform.localScale = Vector3.zero;
        }
        else
        {
            //_hpSlider.SetActive(true);
            _hpSlider.transform.localScale = 
                new Vector3(_sliderMax * health / _maxHealth, 0.08f, transform.localScale.z);
        }
    }
}
