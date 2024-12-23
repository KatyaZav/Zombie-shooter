using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SliderTimer : MonoBehaviour
{
    [SerializeField] Image _image;
    private float _timer;
    private float _currentTimer;

    private bool _isPlaying = true;

    public void SetTime(float time)
    {
        _timer = time;
    }

    private void OnEnable()
    {
        _currentTimer = _timer;
        StartCoroutine(TimerLogic());

        Subscriber.ChangePauseEvent += ChangePause;
    }

    private IEnumerator TimerLogic()
    {
        while (_currentTimer >= 0)
        {
            if (_isPlaying == false)
                yield return null;
            else
            {            
                _currentTimer -= Time.deltaTime;
                float normalizedTime = Mathf.Clamp01(_currentTimer / _timer);
                _image.fillAmount = normalizedTime;
                yield return null;
            }
        }

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Subscriber.ChangePauseEvent -= ChangePause;
    }

    private void ChangePause(bool isPause)
    {
        _isPlaying = isPause == false;
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
    }
}
