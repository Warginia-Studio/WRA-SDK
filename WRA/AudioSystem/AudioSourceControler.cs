using System;
using System.Collections;
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
        
        public void Play(AudioClip audioClip)
        {
            AudioSource.PlayOneShot(audioClip);
        }
        
        public void Stop()
        {
            AudioSource.Stop();
        }
        
        public void ChangeMusic(AudioClip audioClip)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeMusicAnimation(audioClip));
        }

        private void RegisterEvenets()
        {
            AudioManager.Instance.OnVolumeChanged.AddListener(UpdateVolume);
        }
        
        private void UpdateVolume(AudioType audioType, float volume)
        {
            if (audioTypeController != audioType)
                return;
            AudioSource.volume = volume;
        }
        
        private IEnumerator ChangeMusicAnimation(AudioClip clip)
        {
            var volume = AudioManager.Instance.GetVolumeForAudioType(audioTypeController);

            while (AudioSource.volume > 0)
            {
                AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, 0, Time.deltaTime);
                yield return null;
            }

            AudioSource.Stop();
            AudioSource.clip = clip;
            AudioSource.Play();
        
            while (AudioSource.volume < volume)
            {
                AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, volume, Time.deltaTime);
                yield return null;
            }
        }
    }
}
