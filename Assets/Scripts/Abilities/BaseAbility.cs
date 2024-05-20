using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class BaseAbility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject _helpZone;
    [SerializeField] Color32 _color;

    [SerializeField, Space(30)] protected Button _button;
    [SerializeField] protected Image _image;
    [SerializeField] protected float _timeActive;
    [SerializeField] protected float _timeRecharge;
    [SerializeField] protected SliderTimer _timer;

    bool _isActive = true;
    Color32 _baseColor;

    public virtual void Init() 
    {
        _timer.SetTime(_timeRecharge + _timeActive);
        _baseColor = _image.color;
    }

    public void Activate()
    {
        if (_isActive == false)
            return;

        _isActive = false;
        _button.enabled = false;
        _image.color = _color;

        OnClick();

        Invoke("OnDisactivate", _timeActive);
        Invoke("ActivateTimer", _timeActive);

        Invoke("BaseRecharge", _timeRecharge + _timeActive);
    }

    void ActivateTimer()
    {
        _image.color = _baseColor;
        _timer.gameObject.SetActive(true);
    }

    void BaseRecharge()
    {
        _isActive = true;
        _button.enabled = true;
    }

    protected virtual void OnClick() { }
    protected virtual void OnDisactivate() { }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _helpZone.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _helpZone.SetActive(false);
    }
}
