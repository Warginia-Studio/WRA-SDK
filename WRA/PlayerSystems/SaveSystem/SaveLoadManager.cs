using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.PlayerSystems.SaveSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        public enum Status
        {
            idle,
        
            // saving
            findingSaveableObjects,
            convertingSaveableObjects,
            savingObjects,
        
        
            // loading
            loadingData,
            makingObjects
        }

        public static Status ProcessStatus;

        private static List<SLObserver> saveloadObservers = new List<SLObserver>();

        private class GlobalSaveData
        {
            public string SceneName;
            public int SceneId;
            public List<string> SavedData= new List<string>();
        }

        public static void AddSLObserver(SLObserver observer)
        {
            saveloadObservers.Add(observer);
        }

        public static void RemoveSLObserver(SLObserver observer)
        {
            saveloadObservers.Remove(observer);
        }

        public static void Save()
        {
            ProcessStatus = Status.findingSaveableObjects;
            var saveableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>();

            ProcessStatus = Status.convertingSaveableObjects;
            GlobalSaveData data = new GlobalSaveData();

            foreach (var VARIABLE in saveableObjects)
            {
                data.SavedData.Add(VARIABLE.GetSaveData());
            }
            ProcessStatus = Status.savingObjects;
        
            ProcessStatus = Status.idle;
        }

        public static void Load()
        {
            ProcessStatus = Status.loadingData;
        
            ProcessStatus = Status.makingObjects;
        
            ProcessStatus = Status.idle;
        }
    }
}
