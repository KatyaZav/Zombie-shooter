using UnityEngine;
using YG;

public class PlayerSave
{
    public static int Money => YandexGame.savesData.Money;
    public static int Record => YandexGame.savesData.Record;
    public static bool MusicOn => YandexGame.savesData.MusicOn;
    public static WeaponType Pistol => YandexGame.savesData.Pistol;
    public static Ability[] Abilities => YandexGame.savesData.Abilities;

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

    public static void AddBoughtAbility(Ability ability)
    {
        int x = -1;

        for (var i = 0; i < Abilities.Length; i++)
        {
            if (Abilities[i] == ability)
            {
                x = i;
                return;
            }
        }

        if (x == -1)
        {
            Debug.LogError("can't find ability");
            return;
        }

        YandexGame.savesData.Abilities[x].bought++;
        YandexGame.SaveProgress();
    }

    public static void AddBoughtWeapon(WeaponSettings settings)
    {
        switch (settings)
        {
            case WeaponSettings.cartridge:
                YandexGame.savesData.Pistol.cartridge++;
                break;
            case WeaponSettings.power:
                YandexGame.savesData.Pistol.power++;
                break;
            case WeaponSettings.recharge:
                YandexGame.savesData.Pistol.recharge++;
                break;
        }

        YandexGame.SaveProgress();
    }
}

public enum WeaponSettings
{
    cartridge,
    power,
    recharge
}

public class WeaponType
{
    public int cartridge = 0; 
    public int power = 0; 
    public int recharge = 0;
    
    public int cost = 150;
}

public class Ability
{
    public int bought = 0;
    public bool isBought = false;
    public int cost = 200;
}