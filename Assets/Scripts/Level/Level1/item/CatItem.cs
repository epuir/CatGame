using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using level1model;

public class CatItem : BaseItem
{
    public GameObject object1;
    private bool canClick = true;
    public float clickDelay = 0.2f; // 设置一个延时防止快速点击


    public override void OnPointerClick(PointerEventData eventData)
    {
            catdisappear1();
            Level1Model.Instance.CatModel++;
            Debug.Log($"调用次数: {Level1Model.Instance.CatModel}");
       
    }

    

    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }
    void ToggleObject(GameObject target, bool state)
    {
        if (target != null)
        {
            target.SetActive(state);
        }

    }
   

    public void catdisappear1()
    {
        ToggleObject(object1, false);// 隐藏猫
    }

}
