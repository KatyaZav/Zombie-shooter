using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using YG;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] PauseController _pause;
    [SerializeField] Animator _anim;

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Button _rewardButton;
    [SerializeField] int _time;

    private int _money = 0;

    public void ActivateRewardAd()
    {
        _rewardButton.gameObject.SetActive(false);
        YG.YandexGame.RewVideoShow(0);
    }

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

        YandexGame.RewardVideoEvent += GetReward;
    }

    private void GetReward(int obj)
    {
        PlayerSave.AddMoney(_money);
    }

    private void OnDisable()
    {
        _pause.MakePause(false);         

        YandexGame.RewardVideoEvent -= GetReward;
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

        if (_money == 0)
            _rewardButton.gameObject.SetActive(false);

        _rewardButton.enabled = false;

        yield return new WaitForSeconds(0.5f);

        while (curMoney < _money)
        {
            if (moneyPerSec == 0) break;
            curMoney += moneyPerSec;
            _text.text = curMoney.ToString();
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }


        _text.text = _money.ToString();
        _rewardButton.enabled = true;
    }
}
