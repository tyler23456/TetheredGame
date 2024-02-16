using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class SoundFX
    {
        [SerializeField] AudioSource source;
        AudioClip clip;

        public void Play(AudioClip clip, float minPitch = 1f, float maxPitch = 1f, float minVolume = 1f, float maxVolume = 1f)
        {
            source.pitch = Random.Range(minPitch, maxPitch);
            source.volume = Random.Range(minVolume, maxVolume);
            source.PlayOneShot(clip);
        }

        public void Play(List<AudioClip> clips, float minPitch = 1f, float maxPitch = 1f, float minVolume = 1f, float maxVolume = 1f)
        {
            clip = clips[Random.Range(0, clips.Count)];

            if (clip != null)
                Play(clip, minPitch, maxPitch, minVolume, maxVolume);
        }

    }
}