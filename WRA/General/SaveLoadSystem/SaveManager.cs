using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns;
using WRA.Utility.Diagnostics;
using JsonConvert = Unity.Plastic.Newtonsoft.Json.JsonConvert;

public class SaveManager : Singleton<SaveManager>
{
    public SaveData GameState => gameState;
    
    private SaveData gameState;

    public void Load(string saveName)
    {
        FileStream fileStream = new FileStream(Application.dataPath + "/Saves/" + saveName, FileMode.OpenOrCreate);
        StreamReader streamReader = new StreamReader(fileStream);

        var text = streamReader.ReadToEnd();

        gameState = JsonConvert.DeserializeObject<SaveData>(text);
        fileStream.Close();
    }

    public void Save(string saveName)
    {
        gameState.SceneName = SceneManager.GetActiveScene().name;
        
        FileStream fileStream = new FileStream(Application.dataPath + "/Saves/" + saveName, FileMode.OpenOrCreate);
        StreamWriter streamWriter = new StreamWriter(fileStream);

        var text = JsonConvert.SerializeObject(gameState);
        streamWriter.Write(text);
        fileStream.Close();
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
