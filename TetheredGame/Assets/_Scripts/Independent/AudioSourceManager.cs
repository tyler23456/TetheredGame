using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Independent
{
    public class AudioSourceManager : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;

        public void Play()
        {
            audioSource.Play();
        }
    }
}