using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.General
{
    [System.Serializable]
    public class ApplicationProfile
    {
        public SystemLanguage Language = SystemLanguage.English;
        public List<TextAsset> Langs;
        public bool CustomConsole = false;

        public List<KeyedData> fonts;
    }

    [Serializable]
    public class KeyedData
    {
        public string name;
        public Font defaultFont;
        public TMP_FontAsset tmpFont;
    }
}