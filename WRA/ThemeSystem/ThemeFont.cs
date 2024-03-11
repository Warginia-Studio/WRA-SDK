using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.General;

public class ThemeFont : MonoBehaviour
{
    [SerializeField] private string fontCategory = "default";
    private void Awake()
    {
        var fontData = ApplicationProfile.Instance.fonts.Find(ctg => fontCategory == ctg.name);
        var text = GetComponent<Text>();
        if (text != null)
        {
            text.font = fontData.defaultFont;
        }
        var tmp = GetComponent<TMP_Text>();
        if (tmp != null)
        {
            tmp.font = fontData.tmpFont;
        }
    }
}
