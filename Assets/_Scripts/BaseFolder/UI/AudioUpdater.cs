using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioUpdater : MonoBehaviour
{
    private const string MixerName = "Sound";

    [SerializeField] Button _button;
    [SerializeField] Image _image;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private AudioMixer _mixer;

    public void Init()
    {
        _button.onClick.AddListener(OnClick);

        UpdateImage();
    }

    private void OnClick()
    {
        PlayerSave.SwipeSoundOn();
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (PlayerSave.SoundOn)
            _image.sprite = sprites[0];
        else
            _image.sprite = sprites[1];

        _mixer.SetFloat(MixerName, PlayerSave.SoundOn ? 0f : -80f);
    }
}
