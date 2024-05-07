using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bostrap : MonoBehaviour
{
    [SerializeField] BaseAbility[] _abilities;
    [SerializeField] Weapon _weapon;
    [SerializeField] PlayerInventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var e in _abilities)
            e.Init();

        _weapon.Init();
        _inventory.Init();
    }
}
