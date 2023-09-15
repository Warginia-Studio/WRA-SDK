using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPanelData : PanelData
{
    public int StartPanelId { get; set; }
    public string StartPanelName { get; set; }
    public bool UseId { get; set; }
    
    public object SubPanelViewData { get; set; }
}
