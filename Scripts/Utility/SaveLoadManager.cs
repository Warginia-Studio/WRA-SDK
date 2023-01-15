using System;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.Interfaces;
using UnityEngine;

namespace Utility
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
        
        private class GlobalSaveData
        {
            public string SceneName;
            public int SceneId;
            public List<string> SavedData= new List<string>();
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
