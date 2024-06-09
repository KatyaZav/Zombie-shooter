using UnityEngine;
using YG;

public class PlayerSave
{
    public static int Money => YandexGame.savesData.Money;
    public static int Record => YandexGame.savesData.Record;
    public static bool MusicOn => YandexGame.savesData.MusicOn;
    public static int[] Pistol => YandexGame.savesData.Pistol;
    public static int[] Abilities => YandexGame.savesData.Abilities;
    public static string Language => YandexGame.lang;

    public static bool CheakMoneyEnought(int cost) => Money >= cost;


    public static void SetMusicOn(bool isOn)
    {
        YandexGame.savesData.MusicOn = isOn;
        YandexGame.SaveProgress();
    }

    public static void SetMusicOn()
    {
        YandexGame.savesData.MusicOn = !YandexGame.savesData.MusicOn;
        YandexGame.SaveProgress();
    }

    public static void AddMoney(int money)
    {
        YandexGame.savesData.Money = Money + money;
        YandexGame.SaveProgress();
    }

    public static void RemoveMoney(int money)
    {
        YandexGame.savesData.Money = Money - money;
        YandexGame.SaveProgress();
    }

    public static void SetRecord(int record)
    {
        if (Record < record)
        {
            YandexGame.savesData.Record = record;
            YandexGame.NewLeaderboardScores("Scores", record);
            YandexGame.SaveProgress();
        }
    }
    public static void AddBoughtAbility(int index)
    {
        YandexGame.savesData.Abilities[index]++;
        YandexGame.SaveProgress();
    }
    public static void AddBoughtWeapon(WeaponSettings settings)
    {
        YandexGame.savesData.Pistol[(int)settings]++;
        YandexGame.SaveProgress();
    }
}

[System.Serializable]
public enum WeaponSettings
{
    cartridge = 0,
    power = 1,
    recharge = 2
}