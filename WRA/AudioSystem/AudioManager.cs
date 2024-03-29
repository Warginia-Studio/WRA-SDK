using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.General;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.General.SaveLoadSystem;

namespace WRA.AudioSystem
{
    public class AudioManager : MonoBehaviourSingletonAutoCreate<AudioManager>
    {
        public UnityEvent<AudioType, float> OnVolumeChanged = new UnityEvent<AudioType, float>();
        private Dictionary<AudioType, float> volumes =new Dictionary<AudioType, float>()
        {
            { AudioType.effects , 1},
            { AudioType.environment , 1},
            { AudioType.lector , 1},
            { AudioType.music , 1},
            { AudioType.voices , 1},
        };
        
        protected override void OnCreate()
        {
#if UNITY_ANDROID
            volumes[AudioType.effects] = LoadVolume(AudioType.effects);
            volumes[AudioType.environment] = LoadVolume(AudioType.environment);
            volumes[AudioType.lector] = LoadVolume(AudioType.lector);
            volumes[AudioType.music] = LoadVolume(AudioType.music);
            volumes[AudioType.voices] = LoadVolume(AudioType.voices);
#else
            var volumesSettings = UnityFileManagment.LoadObject<Dictionary<AudioType, float>>("/Configs/AudioConfig.cfg");
            if (volumesSettings != null)
            {
                volumes = volumesSettings;
            }
#endif
        }

        private void OnDestroy()
        {
#if UNITY_ANDROID
            PlayerPrefs.SetFloat(AudioType.effects.ToString(), volumes[AudioType.effects]);
            PlayerPrefs.SetFloat(AudioType.environment.ToString(), volumes[AudioType.environment]);
            PlayerPrefs.SetFloat(AudioType.lector.ToString(), volumes[AudioType.lector]);
            PlayerPrefs.SetFloat(AudioType.music.ToString(), volumes[AudioType.music]);
            PlayerPrefs.SetFloat(AudioType.voices.ToString(), volumes[AudioType.voices]);
            PlayerPrefs.Save();
#else
            UnityFileManagment.SaveObject<Dictionary<AudioType, float>>("/Configs/AudioConfig.cfg", volumes);
            OnVolumeChanged.RemoveAllListeners();
#endif
        }

        public void SetVolumeForAudioType(AudioType audioType, float volume)
        {
            volumes[audioType] = volume;
            OnVolumeChanged.Invoke(audioType, volume);
        }

        public float GetVolumeForAudioType(AudioType audioType)
        {
            return volumes[audioType];
        }
        
        private float LoadVolume(AudioType audioType)
        {
            if (PlayerPrefs.HasKey(audioType.ToString()))
            {
                return PlayerPrefs.GetFloat(audioType.ToString());
            }
            return 1;
        }
    }
}