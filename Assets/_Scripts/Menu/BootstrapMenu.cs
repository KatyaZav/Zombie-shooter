using UnityEngine;
using YG;
using TMPro;

public class BootstrapMenu : MonoBehaviour
{
    [SerializeField] AudioUpdater _audio;
    [SerializeField] CoinHolder _coin;

    [SerializeField] ShopPart[] _weapon;
    [SerializeField] ShopPart[] _ability;

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TranslationText _translation;

    [SerializeField] AddIcons _icon;

    void Start()
    {
        if (YandexGame.SDKEnabled)
            Init();

        YandexGame.GetDataEvent += Init;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Init;        
    }

    void Init()
    {
        Cursor.visible = false;

        _audio.Init();
        _coin.Init();

        var i = 0;

        foreach (var e in _weapon)
        {
            e.Init(PlayerSave.Pistol[i]);
            i++;
        }

        i = 0;
        foreach (var e in _ability)
        {
            e.Init(PlayerSave.Abilities[i]);
            i++;
        }

        _text.text = _translation.GetText(PlayerSave.Language) + PlayerSave.Record.ToString();

        _icon.Init();
    }
}
