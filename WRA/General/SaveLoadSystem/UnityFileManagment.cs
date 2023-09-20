using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace WRA.General.SaveLoadSystem
{
    public class UnityFileManagment
    {
        public static T LoadObject<T>(string path) where T : class
        {
            var fullPath = CheckPatch(path);
            var text = Encoding.ASCII.GetString(File.ReadAllBytes(fullPath));
            var obj = JsonConvert.DeserializeObject<T>(text);
            return obj;
        }

        public static void SaveObject<T>(string path, T obj) where T : class
        {
            var fullPath = CheckPatch(path);
            var text = JsonConvert.SerializeObject(obj);
            File.WriteAllBytes(fullPath, Encoding.ASCII.GetBytes(text));
        }

        private static string CheckPatch(string path)
        {
            var fullPath = Application.dataPath + path;
            var dirName = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            return fullPath;
        }
    }
}
