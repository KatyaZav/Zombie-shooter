using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShopPart : MonoBehaviour
{
    [SerializeField] SliderShop _slider;
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] Cost _cost;

    [SerializeField] UnityEvent OnClickEvent;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _buy, _cantbuy;
    
    private int _currentPoints;
    private Color _currentColor;

    public void Init(int points)
    {
        _button.onClick.AddListener(OnClick);
        _currentPoints = Mathf.Clamp(points, 0, _slider.GetMaxSliderValue());

        UpdateSlider();
        _audio.TryInit();
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

    private void OnClick()
    {
        var cost = _cost.GetCost(_currentPoints);

        if (PlayerSave.CheakMoneyEnought(cost))
        {
            _audio.MakeSound(_buy);
            PlayerSave.RemoveMoney(cost);
            OnClickEvent?.Invoke();
            _currentPoints++;
            UpdateSlider();
        }
        else
        {
            _audio.MakeSound(_cantbuy);
            Debug.Log("not enought money");
            MakeAnimation();
        }

    }

    private void OnFillSlider()
    {
        _costText.text = "";
        _button.gameObject.SetActive(false);
        _button.onClick.RemoveListener(OnClick);
    }

    #region Animation
    private void MakeAnimation()
    {
        _currentColor = _costText.color;
        _costText.color = Color.red;
        Invoke("StopAnimation", 2);
    }

    private void StopAnimation()
    {
        _costText.color = _currentColor;
    }
    #endregion

    private void OnValidate()
    {
        _slider = GetComponent<SliderShop>();
        _button = GetComponentInChildren<Button>();
        _costText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
