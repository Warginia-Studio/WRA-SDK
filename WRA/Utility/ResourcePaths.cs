using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WRA.Zenject
{
    [System.Serializable]
    public class ResourcePaths 
    {
        [SerializeField] private string[] dictionaryPaths = new []{ "SDK/" };
        [SerializeField] private string[] objectNames = new[] { "SomeObject" };

        private List<string> allPaths;

        public List<string> GetAllPaths()
        {
            if (allPaths != null)
                return allPaths;
            allPaths = new List<string>();
            foreach (var path in dictionaryPaths)
            {
                foreach (var name in objectNames)
                {
                    allPaths.Add(Path.Combine(path, name));
                }
            }
        
            return allPaths;
        }
    }
}
