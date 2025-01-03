using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class BaseAbility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected int index;
    [SerializeField] protected Image _image;
    [SerializeField] protected float _timeActive;
    [SerializeField] protected float _timeRecharge;
    [SerializeField] protected SliderTimer _timer;
    [SerializeField] protected Button _button;

    [Space(20)]
    [SerializeField] GameObject _helpZone;
    [SerializeField] Color32 _color;

    [SerializeField] GameObject _particle;
    [SerializeField] int[] waitTime = new int[6];
    [SerializeField] int[] _timeAbility = new int[6];

    [Space(10)]
    [Header("Audio")]
    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _on, _off;

    bool _isActive = true;
    Color32 _baseColor;

    public virtual void Init() 
    {
        if (YG.YandexGame.savesData.Abilities[index] == 0)
        {
            gameObject.SetActive(false);
            return;
        }

        _timeActive = _timeAbility[YG.YandexGame.savesData.Abilities[index]-1];
        _timeRecharge = waitTime[YG.YandexGame.savesData.Abilities[index]-1];

        _timer.SetTime(_timeRecharge + _timeActive);
        _baseColor = _image.color;

        _audio.TryInit();
    }
    public void Activate()
    {
        if (_isActive == false)
            return;

        Debug.Log("Activated " + gameObject.name);
        _audio.MakeSound(_on);

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
    protected void MakeSound(AudioClip _clip)
    {
        _audio.MakeSound(_clip);
    }

    protected virtual void OnClick() { }
    protected virtual void OnDisactivate() 
    {
        _audio.MakeSound(_off);
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
