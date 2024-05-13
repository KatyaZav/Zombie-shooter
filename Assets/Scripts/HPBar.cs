using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject _hpSlider;

    float _maxHealth;
    float _sliderMax;

    public void Deactivate()
    {
        _hpSlider.SetActive(false);
    }

    public void Init(float health)
    {
        _maxHealth = health;
        _sliderMax = _hpSlider.transform.localScale.x;
    }

    public void UpdateSlider(float health)
    {
        if (_hpSlider.activeSelf == false)
            _hpSlider.SetActive(true);

        _hpSlider.transform.localScale = new Vector3(_sliderMax * health / _maxHealth, transform.localScale.y, transform.localScale.z);
    }
}
