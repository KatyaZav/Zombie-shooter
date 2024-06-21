using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioComponent : MonoBehaviour
{    
    private AudioSource _sorce;

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
        _sorce.mute = PlayerSave.MusicOn == false;

        if (_sorce.isPlaying && PlayerSave.MusicOn)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        _sorce.loop = isLoop;
        _sorce.clip = clip;
        _sorce.Play();
    }

    private void OnValidate()
    {
        _sorce = GetComponent<AudioSource>();
    }
}
