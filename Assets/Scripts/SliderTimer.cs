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
            _image.fillAmount = _currentTimer/_timer;
            _currentTimer--;
            yield return new WaitForSeconds(1);
        }

        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
    }
}
