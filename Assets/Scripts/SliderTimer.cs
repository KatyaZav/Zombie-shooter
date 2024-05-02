using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderTimer : MonoBehaviour
{
    [SerializeField] Image _image;
    private float _timer;
    private float _currentTimer;


    public void SetTime(float time)
    {
        _timer = time;
    }

    private void OnEnable()
    {
        _currentTimer = _timer;
        StartCoroutine(TimerLogic());
    }

    IEnumerator TimerLogic()
    {
        while (_currentTimer >= 0)
        {
           /* yield return new WaitForSeconds(1);
            _image.fillAmount = Mathf.Lerp(_image.fillAmount, (_currentTimer-1)/_timer, 1);
            _currentTimer--;*/
            
            _currentTimer -= Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(_currentTimer / _timer);
            _image.fillAmount = normalizedTime;
            yield return new WaitForFixedUpdate();
        }

        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
    }
}
