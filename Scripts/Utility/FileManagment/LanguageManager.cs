using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Utility.FileManagment
{
    public class LanguageManager
    {
        private const string DEFAULT_LANGEUAGE = "pl";
        private static Dictionary<string, string> LoadedLang;
        public static void LoadLang(string langName)
        {
            var path = Application.dataPath + "/Resources/Langs/" + langName + ".xml";
        
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
        
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlNode n in doc.SelectNodes("/data/*"))
            {
                d.Add(n.Name, n.InnerText);
            }

            LoadedLang = d;
        }

        public static string GetTransation(string keyWord)
        {
            if(LoadedLang==null)
                LoadLang(DEFAULT_LANGEUAGE);
            return LoadedLang[keyWord];
        }
    }
}
