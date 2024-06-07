using UnityEngine;
using YG;

public class BootstrapMenu : MonoBehaviour
{
    [SerializeField] AudioUpdater _audio;
    [SerializeField] CoinHolder _coin;

    [SerializeField] ShopPart[] _weapon;
    [SerializeField] ShopPart[] _ability;

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
        _audio.Init();
        _coin.Init();

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
