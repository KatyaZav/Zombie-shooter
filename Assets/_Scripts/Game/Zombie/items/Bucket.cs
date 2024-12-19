using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : BaseItems
{
    protected override void OnInit() 
    {
        _zombie.ChangeSpeed(110);
    }

    protected override void OnDestroyed()
    {
        _zombie.ChangeSpeed(10);
        gameObject.SetActive(false);
    }
}
