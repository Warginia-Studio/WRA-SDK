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
        }

        private void Update()
        {
            AudioSource.volume = AudioManager.Instance.GetVolumeForAudioType(audioTypeController);
        }

        public void Play(AudioClip audioClip)
        {
            AudioSource.PlayOneShot(audioClip);
        }
    }
}
