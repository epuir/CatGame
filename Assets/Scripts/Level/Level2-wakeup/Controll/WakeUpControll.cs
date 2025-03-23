using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using Level.Model;
using UnityEngine;
using wakeupmodel;


public class WakeUpControll : BaseLevelController
{
    public Transform UI; // ����1
    public GameObject angry;
    public GameObject sleep;
    public Vector3 offset;
    private float number = 0f; // ����ֱ������ WakeUpModel.Instance.Frequency

    void Update()
    {
        // ʹ�� GetFrequency() ��������Ƶ��
        number = WakeUpModel.Instance.GetFrequency() - WakeUpModel.Instance.FrequencyRange;

        // ���� number ֵ���ƶ�����1
        if (number > 0& UI.position.x <= 3.7)
        {
            // �����ƶ�
            UI.position += offset * Time.deltaTime;
        }
        else if (number < 0& UI.position.y >= -3.7 )
        {
            // �����ƶ�
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


