using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] BaseAbility[] _abilities;
    [SerializeField] Weapon _weapon;
    [SerializeField] PlayerInventory _inventory;
    [SerializeField] Spawner _spawner;

    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _start;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        foreach (var e in _abilities)
            e.Init();

        _weapon.Init();
        _inventory.Init();
        _spawner.Init();

        _audio.MakeSound(_start);
    }
}
