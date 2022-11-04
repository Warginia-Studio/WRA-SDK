using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public abstract class Dropable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [SerializeField] protected DropableConfiguration dropableConfiguration;
    
    protected Image image
    {
        get
        {
            if (_image == null)
            {
                _image = GetComponent<Image>();
            }

            return _image;
        }
    }
    
    private Image _image;

    public abstract void OnPointerEnter(PointerEventData eventData);
    
    public abstract void OnPointerExit(PointerEventData eventData);
    
    public abstract void OnDrop(PointerEventData eventData);

    protected abstract bool IsPossibleToDrop();

    protected virtual void SetStatus(DropableConfiguration.Status status, string customStatusName = "")
    {
        if (dropableConfiguration == null)
            return;
        
        Color finalColor = dropableConfiguration.GetFinalColor(status, customStatusName);
        
    }
}
