using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : BaseAbility
{
    protected override void OnClick()
    {
        Target.Instance.MakeUnLimited(true);
        base.OnClick();
    }
    protected override void OnDisactivate()
    {
        Target.Instance.MakeUnLimited(false);
        base.OnDisactivate();
    }
}
