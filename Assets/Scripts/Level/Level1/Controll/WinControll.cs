using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class WinControll : MonoBehaviour
{
    public GameObject winImage;
    [SerializeField] private UnityEvent Lose;
    private void Update()
    {
        if (Level1Model.Instance.CatModel >= 70f)
        {
            win();
        }
        if (Level1Model.Instance.AllTime >= 180f)
        {
            if (Level1Model.Instance.CatModel < 70f)
            {
                lose();
                
            }
        }
    }
    private void lose()
    {
        Lose.Invoke(); 
        Level1Model.Instance.AllTime = 0;
        Level1Model.Instance.CatModel = 0;
    }
    private void win()
    {
       
            winImage.SetActive(true);
       
    }
   
}
