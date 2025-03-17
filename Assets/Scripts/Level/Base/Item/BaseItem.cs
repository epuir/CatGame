using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseItem : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    protected BaseLevelController _controller;

    protected virtual void Start()
    {
        _controller = BaseLevelController.Instance;
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public abstract void OnPointerEnter(PointerEventData eventData);

    public abstract void OnPointerExit(PointerEventData eventData);

    protected static bool OnPointerClick()
    {
        throw new NotImplementedException();
    }
}
