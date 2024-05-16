using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartZombie : BaseZombie
{
    [SerializeField] ZombiePart[] _parts;
    [SerializeField] BaseItems[] _items;

    public override void Init(Vector3 pos)
    {
        base.Init(pos);

        foreach (var e in _parts)
        {
            e.DamagePartEvent += RemoveHp;
        }

        foreach (var e in _items)
        {
            if(e.CheckProbability())
                e.Activate();
        }

        //gameObject.transform.localPosition = pos;
    }
}
