using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAbility : BaseAbility
{
    [SerializeField] Spawner _spawner;
    
    protected override void OnClick() 
    {
        _spawner.StopAllZombies(true);
        _spawner.PoisonAllZombies(2, _timeActive);
        base.OnClick();
    }
    protected override void OnDisactivate()
    {
        _spawner.StopAllZombies(false);
        base.OnDisactivate();
    }
}
