using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : BaseAbility
{
    [SerializeField] AudioClip _cantUse;
    protected override void OnClick()
    {
        /*if (Target.Instance.CheackCanShoot() == false)
        {
            MakeSound(_cantUse);
            return;
        }*/

        Target.Instance.MakeUnLimited(true);
        base.OnClick();
    }
    protected override void OnDisactivate()
    {
        Target.Instance.MakeUnLimited(false);
        base.OnDisactivate();
    }
}
