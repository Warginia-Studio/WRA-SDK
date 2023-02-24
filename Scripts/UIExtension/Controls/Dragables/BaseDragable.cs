using System;
using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class BaseDragable : CIHolder<ContainerSlot<ContainerItem> , ContainerItem>, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 GrabOffset { get; private set; }

    protected Vector3 basePosition;

    protected CanvasGroup canvasGroup;
    protected bool grabbed = false;

    protected virtual void Awake()
    {
        basePosition = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.4f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        GrabOffset = transform.position - Input.mousePosition;
        grabbed = true;
        DragDropManager.Instance.BeginDragItem(this);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + GrabOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        grabbed = false;
        DragDropManager.Instance.EndDragItem();
    }

    public void SetBasePosition(Vector2 position)
    {
        transform.position = position;
        basePosition = transform.position;
    }
}
