using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubPanelViewBase : MonoBehaviour
{
    public abstract void OnShow(object data);

    public abstract void OnHide();
}
