using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartZombie : BaseZombie
{
    [SerializeField] ZombiePart[] _parts;

    public override void Init()
    {
        base.Init();

        foreach (var e in _parts)
        {
            e.DamagePartEvent += RemoveHp;
        }
    }

    private void OnEnable()
    {
        Init();
    }
}
