using UnityEngine;
using YG;

public class AddIcons : MonoBehaviour
{
    bool getProm;

    /*public void Init()
    {
        YandexGame.PromptSuccessEvent += AddMoney;

        Debug.Log("promt can show "+ YandexGame.EnvironmentData.promptCanShow);
        //gameObject.SetActive(YandexGame.EnvironmentData.promptCanShow);
    }

    private void OnDisable()
    {
        YandexGame.PromptSuccessEvent -= AddMoney;        
    }

    public void AddIcon()
    {
        YandexGame.PromptShow();
    }*/

    public void AddMoney()
    {
        PlayerSave.AddMoney(150);
        gameObject.SetActive(false);
    }
}
