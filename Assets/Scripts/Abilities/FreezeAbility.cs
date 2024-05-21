using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAbility : BaseAbility
{
    [SerializeField] Spawner _spawner;
    protected override void OnClick() 
    {
        _spawner.StopAllZombies(true);
    }
    protected override void OnDisactivate()
    {
        _spawner.StopAllZombies(false);
    }
}
