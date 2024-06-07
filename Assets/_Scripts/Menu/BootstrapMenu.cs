using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapMenu : MonoBehaviour
{
    //[SerializeField] SliderMenuUpdater _update;
    [SerializeField] ShopPart[] _shopParts;

    void Start()
    {
        //_update.Init();

        foreach (var e in _shopParts)
        {
            e.Init(0);
        }
    }

}
