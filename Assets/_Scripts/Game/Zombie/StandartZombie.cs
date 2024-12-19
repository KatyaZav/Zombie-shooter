using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartZombie : BaseZombie
{
    [SerializeField] BaseItems[] _items;

    int _killCount = 0;

    public override void Init(Vector3 pos)
    {
        base.Init(pos);       

        foreach (var e in _items)
        {
            var koeficient = ReturnKoef(_killCount);

            if(e.CheckProbability(koeficient))
                e.Activate();
        }

        //gameObject.transform.localPosition = pos;
    }

    protected override void OnDead()
    {
        base.OnDead();
        _killCount++;
    }

    private float ReturnKoef(int killCount)
    {
        var koef = killCount / 6f;
        koef = Mathf.Clamp(koef, 1, 10);

        return koef;
    }
}
