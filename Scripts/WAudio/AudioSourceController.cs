using UnityEngine;
using AudioType = DependentObjects.Enums.AudioType;

namespace WAudio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : MonoBehaviour
    {
        public AudioSource AudioSource => audioSource;
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
