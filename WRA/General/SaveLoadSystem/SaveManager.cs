using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns;
using WRA.Utility.Diagnostics;

namespace WRA.General.SaveLoadSystem
{
    public class SaveManager : Singleton<SaveManager>
    {
        public SaveData GameState => gameState;
    
        private SaveData gameState;

        public void Load(string saveName)
        {
            gameState = UnityFileManagment.LoadObject<SaveData>("/Saves/" + saveName);
        }

        public void Save(string saveName)
        {
            gameState.SceneName = SceneManager.GetActiveScene().name;
        
            UnityFileManagment.SaveObject("/Saves/" + saveName, gameState);
        }

        public void RegisterObjectToSave(object saveableObject)
        {
            var obj = gameState.AllObjects.Find(ctg => ctg.ObjectData == saveableObject);
            if (obj != null)
            {
                WraDiagnostics.LogError($"Objects is registered as saveable {saveableObject.GetType().Name}", Color.red);
                return;
            }

            gameState.AllObjects.Add(new SimpleObject() { ObjectData = saveableObject, Type = saveableObject.GetType()});
        }

        public void UnRegisterObjectToSave(object saveableObject)
        {
            var obj = gameState.AllObjects.FindIndex(ctg => ctg.ObjectData == saveableObject);

            if (obj == -1)
                return;

            gameState.AllObjects.RemoveAt(obj);
        }

        public T GetSaveData<T>() where T : class
        {
            var obj = gameState.AllObjects.Find(ctg => ctg.Type is T);

            return obj.ObjectData as T;
        }
    }
}
