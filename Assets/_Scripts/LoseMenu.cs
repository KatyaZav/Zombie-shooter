using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] PauseController _pause;
    [SerializeField] Animator _anim;

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] int _time;

    private int _money = 0;

    public void SetMoney(int money)
    {
        _money = money;
    }

    public void StartCoinCoroutine()
    {
        StartCoroutine(MoneyCoiner());
    }

    private void OnEnable()
    {
        _pause.MakePause(true);
        _anim.SetTrigger("on");
    }

    private void OnDisable()
    {
        _pause.MakePause(false);         
    }

    private void OnValidate()
    {
        _anim = GetComponent<Animator>();
    }

    private IEnumerator MoneyCoiner()
    {
        int moneyPerSec = _money / _time;
        int curMoney = 0;
        _text.text = curMoney.ToString();

        yield return new WaitForSeconds(0.5f);

        while (curMoney < _money)
        {
            if (moneyPerSec == 0) break;
            curMoney += moneyPerSec;
            _text.text = curMoney.ToString();
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }

        _text.text = _money.ToString();
    }
}
