using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioActionTrigger : BaseActionTrigger
{
    private AudioSource _audioSource;
    private bool _audioPlayed = false;

    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

   
    public void PlayAudioClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
        Invoke(nameof(AudioPlayed), clip.length);
    }

    private void AudioPlayed() { _audioPlayed = true; }
    public override bool GetConditionState()
    {
        return _audioPlayed;
    }
}
