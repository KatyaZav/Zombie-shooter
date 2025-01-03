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
        _anim.SetTrigger("die");
        _isStop = true;
        _isDead = true;

        Invoke("DeactivateZombie", 0.5f);
    }

    protected override void OnDamaged()
    {
        _anim.SetTrigger("damage");

        if (_isStop == false)
        {
            _isStop = true;
            Invoke("UnFreeze", 0.4f);
        }
    }

    private void UnFreeze()
    {
        _isStop = false;
    }

    private float ReturnKoef(int killCount)
    {
        var koef = killCount / 6f;
        koef = Mathf.Clamp(koef, 1, 10);

        return koef;
    }
}
