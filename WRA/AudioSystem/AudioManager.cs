using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.General;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.General.SaveLoadSystem;
using Zenject;

namespace WRA.AudioSystem
{
    public class AudioManager : MonoInstaller
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

        protected void Awake()
        {
            OnCreate();
        }

        void OnCreate()
        {
            volumes[AudioType.effects] = LoadVolume(AudioType.effects);
            volumes[AudioType.environment] = LoadVolume(AudioType.environment);
            volumes[AudioType.lector] = LoadVolume(AudioType.lector);
            volumes[AudioType.music] = LoadVolume(AudioType.music);
            volumes[AudioType.voices] = LoadVolume(AudioType.voices);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetFloat(AudioType.effects.ToString(), volumes[AudioType.effects]);
            PlayerPrefs.SetFloat(AudioType.environment.ToString(), volumes[AudioType.environment]);
            PlayerPrefs.SetFloat(AudioType.lector.ToString(), volumes[AudioType.lector]);
            PlayerPrefs.SetFloat(AudioType.music.ToString(), volumes[AudioType.music]);
            PlayerPrefs.SetFloat(AudioType.voices.ToString(), volumes[AudioType.voices]);
            PlayerPrefs.Save();
        }
        
        public override void InstallBindings()
        {
            Container.Bind<AudioManager>().FromInstance(this).AsSingle();
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