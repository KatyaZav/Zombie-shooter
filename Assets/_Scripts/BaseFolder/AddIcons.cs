using UnityEngine;
using YG;

public class AddIcons : MonoBehaviour
{
    public void Init()
    {
        YandexGame.PromptSuccessEvent += AddMoney;

        gameObject.SetActive(YandexGame.EnvironmentData.promptCanShow);
    }

    private void OnDisable()
    {
        YandexGame.PromptSuccessEvent -= AddMoney;        
    }

    public void AddIcon()
    {
        YandexGame.PromptShow();
    }

    private void AddMoney()
    {
        PlayerSave.AddMoney(150);
        gameObject.SetActive(false);
    }
}
