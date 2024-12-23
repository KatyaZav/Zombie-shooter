using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicUpdater : MonoBehaviour
{
    private const string MixerName = "Music";
    
    [SerializeField] Button _button;
    [SerializeField] Image[] _image;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private AudioMixer _mixer;

    public void Init()
    {
        _button.onClick.AddListener(OnClick);

        UpdateImage();
    }

    private void OnClick()
    {
        PlayerSave.SwipeMusicOn();
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (PlayerSave.MusicOn)
            foreach (var image in _image) 
                image.sprite = sprites[0];
        else
            foreach (var image in _image)
                image.sprite = sprites[1];

        _mixer.SetFloat(MixerName, PlayerSave.MusicOn ? 0f : -80f);
    }
}
