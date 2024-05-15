using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePatch :BaseItems
{
    protected override void OnInit()
    {
        _zombie.ChangeSpeed(20);
    }

    protected override void OnDestroyd()
    {
        _zombie.ChangeSpeed(120);
        gameObject.SetActive(false);
    }
}
