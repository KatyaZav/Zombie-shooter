using UnityEngine;
using YG;

public class PlayerSave
{
    public static int Money => YandexGame.savesData.Money;
    public static int Record => YandexGame.savesData.Record;
    public static bool SoundOn => YandexGame.savesData.SoundOn;
    public static bool MusicOn => YandexGame.savesData.MusicOn;
    public static int[] Pistol => YandexGame.savesData.Pistol;
    public static int[] Abilities => YandexGame.savesData.Abilities;
    public static string Language => YandexGame.lang;
    public static int GameCount => YandexGame.savesData.GameCount;

    public static void GetMinAndMax(out float a, out float b)
    {
        if (GameCount < 5)
        {
            a = 0.4f;
            b = 1f;
        }
        else if (GameCount < 15)
        {
            a = 0.7f;
            b = 1.1f;
        }
        else if (GameCount < 35)
        {
            a = 0.8f;
            b = 1.11f;
        }
        else
        {
            a = 0.9f;
            b = 1.12f;
        }
    }

    public static bool CheakMoneyEnought(int cost) => Money >= cost;

    public static void AddGameCount()
    {
        YandexGame.savesData.GameCount++;
        YandexGame.SaveProgress();
    }

    public static void SetMusicOn(bool isOn)
    {
        YandexGame.savesData.SoundOn = isOn;
        YandexGame.SaveProgress();
    }

    public static void SwipeSoundOn()
    {
        YandexGame.savesData.SoundOn = !YandexGame.savesData.SoundOn;
        YandexGame.SaveProgress();
    }

    public static void SwipeMusicOn()
    {
        YandexGame.savesData.MusicOn = !YandexGame.savesData.MusicOn;
        YandexGame.SaveProgress();
    }

    public static void AddMoney(int money)
    {
        YandexGame.savesData.Money = Money + money;
        YandexGame.SaveProgress();
        Subscriber.StartChangeMoneyEvent();
    }

    public static void RemoveMoney(int money)
    {
        YandexGame.savesData.Money = Money - money;
        YandexGame.SaveProgress();
        Subscriber.StartChangeMoneyEvent();
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