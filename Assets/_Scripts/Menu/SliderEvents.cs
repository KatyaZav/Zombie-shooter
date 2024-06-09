using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEvents : MonoBehaviour
{
    public void BuyWeapon(int settings)
    {
        PlayerSave.AddBoughtWeapon((WeaponSettings)settings);
    }

    public void BuyAbulity(int index)
    {
        PlayerSave.AddBoughtAbility(index);
    }
}
