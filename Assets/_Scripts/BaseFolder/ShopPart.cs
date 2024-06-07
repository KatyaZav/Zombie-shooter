using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPart : MonoBehaviour
{
    [SerializeField] SliderShop _slider;
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] Cost _cost;

    private int _currentPoints;

    public void Init(int points)
    {
        _button.onClick.AddListener(AddPointBought);
        _currentPoints = Mathf.Clamp(points, 0, _slider.GetMaxSliderValue());

        UpdateSlider();
    }

    public void UpdateSlider()
    {
        _slider.SetSlider(_currentPoints);

        if (_slider.IsGettedMaxValue())
        {
            OnFillSlider();
        }
        else
        {
            _costText.text = _cost.GetCost(_currentPoints).ToString(); 
        }
    }

    private void AddPointBought()
    {
        _currentPoints++;
        UpdateSlider();
    }

    private void OnFillSlider()
    {
        _costText.text = "";
        _button.gameObject.SetActive(false);
        _button.onClick.RemoveListener(AddPointBought);
    }

    private void OnValidate()
    {
        _slider = GetComponent<SliderShop>();
        _button = GetComponentInChildren<Button>();
        _costText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
