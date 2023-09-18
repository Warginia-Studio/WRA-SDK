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

        protected override void OnCreate()
        {
            
        }

        public void SetVolumeForAudioType(AudioType audioType, float volume)
        {
            volumes[audioType] = volume;
        }

        public float GetVolumeForAudioType(AudioType audioType)
        {
            return volumes[audioType];
        }

        public string GetSaveData()
        {
            return "";
        }

        public void LoadFromData(string data)
        {
            
        }
    }
}