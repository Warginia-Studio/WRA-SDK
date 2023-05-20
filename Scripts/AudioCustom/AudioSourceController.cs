using System;
using UnityEngine;
using AudioType = DependentObjects.Enums.AudioType;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : MonoBehaviour
    {
        [SerializeField] private AudioType audioTypeController;

        private AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            audioSource.volume = AudioManager.Instance.GetVolumeForAudioType(audioTypeController);
        }

        public void Play(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
