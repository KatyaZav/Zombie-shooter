using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class BaseAbility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] int index;
    [SerializeField] protected Image _image;
    [SerializeField] protected float _timeActive;
    [SerializeField] protected float _timeRecharge;
    [SerializeField] protected SliderTimer _timer;
    [SerializeField] protected Button _button;

    [Space(20)]
    [SerializeField] GameObject _helpZone;
    [SerializeField] Color32 _color;

    [SerializeField] GameObject _particle;
    [SerializeField] int[] waitTime;

    bool _isActive = true;
    Color32 _baseColor;

    public virtual void Init() 
    {
        _timeActive = 1.5f*YG.YandexGame.savesData.Abilities[index];
        _timeRecharge = waitTime[YG.YandexGame.savesData.Abilities[index]];

        if (YG.YandexGame.savesData.Abilities[index] == 0)
            gameObject.SetActive(false);

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

        _particle.SetActive(true);

        OnClick();

        Invoke("OnDisactivate", _timeActive);
        Invoke("ActivateTimer", _timeActive);

        Invoke("BaseRecharge", _timeRecharge + _timeActive);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _helpZone.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _helpZone.SetActive(false);
    }

    protected virtual void OnClick() { }
    protected virtual void OnDisactivate() 
    {
        _particle.SetActive(false);
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
}
