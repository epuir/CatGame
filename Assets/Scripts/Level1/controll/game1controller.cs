using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;

public class game1controller : BaseLevelController
{
    public GameObject object1;
    
    public void catdisappear1()
    {

        Debug.Log("���");
        ToggleObject(object1, false);// ����è
    }
    void ToggleObject(GameObject target, bool state)
    {
        if (target != null)
        {
            target.SetActive(state);
        }

    }
}
   
