using System;
using System.Collections.Generic;
using WRA.General.Patterns;

namespace WRA.AudioSystem
{
    public class AudioManager : MonoBehaviourSingletonAutoCreate<AudioManager>
    {
        private Dictionary<AudioType, float> volumes =new Dictionary<AudioType, float>()
        {
            { AudioType.effects , 1},
            { AudioType.environment , 1},
            { AudioType.lector , 1},
            { AudioType.music , 1},
            { AudioType.voices , 1},
        };

        private void Awake()
        {
            OnCreate();
        }

        protected override void OnCreate()
        {
            var volumesSettings = UnityFileManagment.LoadObject<Dictionary<AudioType, float>>("/Configs/AudioConfig.cfg");
            if (volumesSettings == null)
                return;

            volumes = volumesSettings;
        }

        private void OnDestroy()
        {
            UnityFileManagment.SaveObject<Dictionary<AudioType, float>>("/Configs/AudioConfig.cfg", volumes);
        }

        public void SetVolumeForAudioType(AudioType audioType, float volume)
        {
            volumes[audioType] = volume;
        }

        public float GetVolumeForAudioType(AudioType audioType)
        {
            return volumes[audioType];
        }
    }
}