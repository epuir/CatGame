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
