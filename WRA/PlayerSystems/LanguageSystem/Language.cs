using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using WRA.General;

public class Language
{
    public string ShortLanguageName { get; set; }
    public string LanguageName { get; set; }
    public Dictionary<string, LanguageItem> LanguageItems { get; }

    public Language(string languageData)
    {
        LanguageItems = new Dictionary<string, LanguageItem>();
        ParseLanguageData(languageData);
    }

    public string GetTranslation(string key)
    {
        if (LanguageItems.ContainsKey(key))
        {
            return LanguageItems[key].Translation;
        }

        LanguageMissingTranslationsLogger.AddMissingTranslations(key);
        LanguageMissingTranslationsLogger.SaveMissingTranslations();
        return key;
    }

#if UNITY_EDITOR
    public string GetLanguageAsXml()
    {
        XmlDocument doc = new XmlDocument();
        XmlElement data = doc.CreateElement("data");
        data.SetAttribute("languageShort", ShortLanguageName);
        data.SetAttribute("languageName", LanguageName);
        doc.AppendChild(data);
        foreach (var item in LanguageItems)
        {
            XmlNode category = doc.SelectSingleNode("data/" + item.Value.Category);
            if (category == null)
            {
                category = doc.CreateElement("" + item.Value.Category);
                var atribute = doc.CreateAttribute("category");
                atribute.Value = item.Value.Category;
                category.Attributes.Append(atribute);
                data.AppendChild(category);
            }

            XmlElement element = doc.CreateElement(item.Key);
            element.InnerText = item.Value.Translation;
            category.AppendChild(element);
        }

        return doc.OuterXml;
    }

    public void AddTranslation(string key, LanguageItem languageItem)
    {
        LanguageItems.Add(key, languageItem);
    }
#endif
    private void ParseLanguageData(string languageData)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(languageData);
        ShortLanguageName = doc.SelectSingleNode("data").Attributes["languageShort"].Value;
        LanguageName = doc.SelectSingleNode("data").Attributes["languageName"].Value;
        ParseLanguageItems(doc);
    }

    private void ParseLanguageItems(XmlDocument document)
    {
        XmlNodeList languageItems = document.SelectNodes("/data/*");
        foreach (XmlNode item in languageItems)
        {
            if (item.Attributes["category"] != null)
            {
                var category = item.Name;
                XmlNodeList nodes = document.SelectNodes("/data/" + item.Name + "/*");
                foreach (XmlNode node in nodes)
                {
                    AddTranslation(node.Name, category, node.InnerText);
                }
            }
            else
            {
                AddTranslation(item.Name, "ND", item.InnerText);
            }
        }
    }
    
    private void AddTranslation(string key, string category, string translation)
    {
        LanguageItem languageItem = new LanguageItem();
        languageItem.Category = category;
        languageItem.Translation = translation;
        LanguageItems.Add(key, languageItem);
    }

    [MenuItem("thiief01/test")]
    public static void Load()
    {
        Language language = new Language(ApplicationProfile.Instance.Langs[0].text);
        var xml = language.GetLanguageAsXml();
        Debug.Log(xml);
        StreamWriter sw = new StreamWriter("Assets/Language.xml");
        sw.Write(xml);
        sw.Close();
    }
}