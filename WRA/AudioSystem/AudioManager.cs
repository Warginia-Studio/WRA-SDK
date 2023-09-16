using System.Collections.Generic;
using WRA.General.Patterns;
using WRA.PlayerSystems.SaveSystem;

namespace WRA.AudioSystem
{
    public class AudioManager : MonoBehaviourSingletonAutoCreate<AudioManager>, ISaveable
    {
        private Dictionary<AudioType, float> volumes =new Dictionary<AudioType, float>()
        {
            { AudioType.effects , 1},
            { AudioType.environment , 1},
            { AudioType.lector , 1},
            { AudioType.music , 1},
            { AudioType.voices , 1},
        };


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

        protected override void OnCreate()
        {
            
        }
    }
}