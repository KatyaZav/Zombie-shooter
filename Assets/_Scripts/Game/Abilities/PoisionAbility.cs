using System;
using UnityEngine;

public class PoisionAbility : BaseAbility
{
    [SerializeField] Spawner _spawner;
    [SerializeField] PlayerInventory _inv;
    [SerializeField] float _damage;

    [SerializeField] float[] _damages = new float[8];

    protected override void OnClick()
    {
        //if (Random.Range(0, 10) <= 1)
        //    _inv.Hit(1);

        _spawner.PoisonAllZombies(_damages[YG.YandexGame.savesData.Abilities[index] - 1], _timeActive);
        base.OnClick();
    }
}
