using UnityEngine;
using YG;
using TMPro;

public class BootstrapMenu : MonoBehaviour
{
    [SerializeField] AudioUpdater _audio;
    [SerializeField] MusicUpdater _musAudio;
    [SerializeField] CoinHolder _coin;

    [SerializeField] ShopPart[] _weapon;
    [SerializeField] ShopPart[] _ability;

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TranslationText _translation;

    [SerializeField] GameObject left, center;

    //[SerializeField] AddIcons _icon;

    [SerializeField] private int _buildVersion;

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
        Debug.Log("Build version " + _buildVersion);

        if (YandexGame.EnvironmentData.payload == "DeleteSaves")
        {
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress(); 
        }

        Cursor.visible = false;

        _audio.Init();
        _musAudio.Init();
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

        //_icon.Init();

        left.SetActive(false);
        center.SetActive(false);

        if (PlayerSave.GameCount >= 1)
        {
            center.SetActive(true);
        }
        if (PlayerSave.GameCount >= 2)
        {
            left.SetActive(true);
        }
    }
}
