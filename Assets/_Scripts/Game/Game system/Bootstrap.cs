using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bootstrap : MonoBehaviour
{
    private const string SoundMixerName = "Sound";
    private const string MusicMixerName = "Music";

    [SerializeField] BaseAbility[] _abilities;
    [SerializeField] Weapon _weapon;
    [SerializeField] PlayerInventory _inventory;
    [SerializeField] Spawner _spawner;

    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _start;

    [SerializeField] private AudioMixer _audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        _audioMixer.SetFloat(SoundMixerName, PlayerSave.SoundOn ? 0f : -80f);
        _audioMixer.SetFloat(MusicMixerName, PlayerSave.MusicOn ? 0f : -80f);

        Cursor.visible = false;

        foreach (var e in _abilities)
            e.Init();

        _weapon.Init();
        _inventory.Init();
        _spawner.Init();

        _audio.TryInit();
        _audio.MakeSound(_start);
    }
}
