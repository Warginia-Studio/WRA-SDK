using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

public abstract class PopupBase<T> : MonoBehaviourSingletonAutoLoadUI<T> where T : MonoBehaviour
{
    public abstract void Open();

    public abstract void Close();
}
