using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using Level.Model;
using UnityEngine;
using wakeupmodel;


public class WakeUpControll : BaseLevelController
{
    public Transform UI; // 物体1
    public GameObject angry;
    public GameObject sleep;
    public Vector3 offset;
    private float number = 0f; // 不再直接依赖 WakeUpModel.Instance.Frequency

    void Update()
    {
        // 使用 GetFrequency() 方法计算频率
        number = WakeUpModel.Instance.GetFrequency() - WakeUpModel.Instance.FrequencyRange;

        // 根据 number 值来移动物体1
        if (number > 0& UI.position.x <= 3.7)
        {
            // 向上移动
            UI.position += offset * Time.deltaTime;
        }
        else if (number < 0& UI.position.y >= -3.7 )
        {
            // 向下移动
            UI.position -= offset * Time.deltaTime;
        }
        if (UI.position.y <= -1.6)
        {
            sleep.SetActive(true);
        }
        else
        {
            sleep.SetActive(false);
        }
        if (UI.position.y >= +1.6)
        {
            angry.SetActive(true);
        }
        else
        {
            angry.SetActive(false);
        }


    }
}


