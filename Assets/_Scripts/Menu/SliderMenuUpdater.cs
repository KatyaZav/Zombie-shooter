using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderMenuUpdater : MonoBehaviour
{
    [SerializeField] SliderShop _weaponCartridge, _weaponPower, _weaponRecharge;

    [Space(20)]
    [SerializeField] SliderShop[] _abilities;

    [Space(20)]
    [SerializeField] TextMeshProUGUI _textRecord;

    public void Init()
    {
        _weaponCartridge.SetSlider(PlayerSave.Pistol.cartridge);
        _weaponPower.SetSlider(PlayerSave.Pistol.power);
        _weaponRecharge.SetSlider(PlayerSave.Pistol.recharge);

        for (var i = 0; i < _abilities.Length; i++)
            _abilities[i].SetSlider(PlayerSave.Abilities[i].bought);

        _textRecord.text = PlayerSave.Record.ToString();
    }
}
