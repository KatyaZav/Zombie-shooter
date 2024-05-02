using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartZombie : BaseZombie
{
    public override void Init()
    {
        base.Init();

        _speed = 5;
    }
}
