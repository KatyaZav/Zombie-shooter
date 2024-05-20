using System.Collections;
using System.Collections.Generic;
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
        if (_isInit == false)
        {
            _sliderMax = _hpSlider.transform.localScale.x;
            _isInit = true;
        }

        _maxHealth = health;
        _hpSlider.SetActive(true);
    }

    public void UpdateSlider(float health)
    {
        //if (_hpSlider.activeSelf == false)

        if (health <= 0)
        {
            _hpSlider.transform.localScale = Vector3.zero;
        }
        else
            _hpSlider.transform.localScale = 
                new Vector3(_sliderMax * health / _maxHealth, transform.localScale.y, transform.localScale.z);
    }
}
