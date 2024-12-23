using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioComponent : MonoBehaviour
{    
    private AudioSource _sorce;
    private bool wasInit = false;

    //[SerializeField] private AudioMixerGroup _mixerGroup;

    public void ChangePitch()
    {
        _sorce.pitch = Random.Range(0.8f, 1.2f);
    }

    public void Stop()
    {
        _sorce.Stop();
    }

    public void MakeSound(AudioClip clip, bool isLoop = false)
    {
        if (_sorce == null)
            throw new System.Exception("Audio Source is null");

        _sorce.mute = PlayerSave.MusicOn == false;

        if (_sorce.isPlaying && PlayerSave.MusicOn)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        _sorce.loop = isLoop;
        _sorce.clip = clip;
        _sorce.Play();
    }

    public void TryInit()
    {
        if (wasInit)
            return;

        OnValidate();
        wasInit = true;
        //_sorce.outputAudioMixerGroup = _mixerGroup;
    }

    private void OnValidate()
    {
        _sorce = GetComponent<AudioSource>();
        _sorce.playOnAwake = false;
    }
}
