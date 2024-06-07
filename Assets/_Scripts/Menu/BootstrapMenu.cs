using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapMenu : MonoBehaviour
{
    [SerializeField] ShopPart[] _weapon;
    [SerializeField] ShopPart[] _ability;

    void Start()
    {
        Init();
    }

    void Init()
    {
        foreach (var e in _weapon)
        {
            e.Init(0);
        }

        foreach (var e in _ability)
        {
            e.Init(0);
        }
    }
}
