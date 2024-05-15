using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheld : BaseItems
{
    protected override void OnInit()
    {
        _zombie.ChangeSpeed(30);
    }

    protected override void OnDestroyd()
    {
        _zombie.ChangeSpeed(130);
        gameObject.SetActive(false);
    }
}
