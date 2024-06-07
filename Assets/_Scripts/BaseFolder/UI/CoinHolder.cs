using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinHolder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyText;

    public void Init()
    {
        UpdateCoin();

        Subscriber.ChangeMoneyEvent += UpdateCoin;
    }

    private void OnDisable()
    {
        Subscriber.ChangeMoneyEvent -= UpdateCoin;        
    }

    public void UpdateCoin()
    {
        _moneyText.text = PlayerSave.Money.ToString();
    }

    private void OnValidate()
    {
        _moneyText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
