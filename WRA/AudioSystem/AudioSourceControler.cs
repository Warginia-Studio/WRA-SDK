using System;
using UnityEngine;

namespace WRA.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceControler : MonoBehaviour
    {
        public AudioSource AudioSource { get; private set; }
        [SerializeField] private AudioType audioTypeController;
        
        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            RegisterEvenets();
        }

        private void OnDestroy()
        {
            UnRegisterEvenets();
        }
        
        public void Play(AudioClip audioClip)
        {
            AudioSource.PlayOneShot(audioClip);
        }

        private void RegisterEvenets()
        {
            AudioManager.Instance.OnVolumeChanged.AddListener(UpdateVolume);
        }

        private void UnRegisterEvenets()
        {
            AudioManager.Instance.OnVolumeChanged.RemoveListener(UpdateVolume);
        }

        private void UpdateVolume(AudioType audioType, float volume)
        {
            if (audioTypeController != audioType)
                return;
            AudioSource.volume = volume;
        }
    }
}
