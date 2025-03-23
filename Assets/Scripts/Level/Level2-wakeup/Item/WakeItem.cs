using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.EventSystems;
using wakeupmodel;
using static UnityEngine.Rendering.DebugUI;

public class WakeItem : BaseItem
{
    private float timer = 0f;
    private bool isClicked = false;
    public Animator animatorCat;
    public Animator animatorHand;
    public string triggerName1 = "SwitchAnimation1";
    public string triggerName2 = "SwitchAnimation2";
    public string triggerName3 = "SwitchAnimation3"; 
    public string triggerName4 = "SwitchAnimation4";
    void Update()
    {
        // ÿ֡����ʱ��
        timer += Time.deltaTime;

        // ÿ����0.01�룬������ֵ
        if (timer >= 0.01f)
        {
            WakeUpModel.Instance.FrequencyTime += 0.01f; // ��ֵ����0.01
            timer = 0f;     // ���ü�ʱ��
        }
        if (WakeUpModel.Instance.FrequencyTime > 1f) // ÿ���Ӽ���һ�ε��Ƶ��
        {
            // ���ü�ʱ��
            WakeUpModel.Instance.FrequencyTime = 0f;
            WakeUpModel.Instance.clickModel = 0f;
        }
        // ��ӡ��ǰֵ�������Ƴ����У�
        Debug.Log("��ǰ��ֵ: " + WakeUpModel.Instance.FrequencyTime);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.03f);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        WakeUpModel.Instance.clickModel += 1f;
        
        
        isClicked = true;
        WakeUpModel.Instance.clickModel++;
        animatorCat.SetTrigger(triggerName2);
        Debug.Log("���");
        Delay();
        animatorCat.SetTrigger(triggerName1);

    }



    public override void OnPointerEnter(PointerEventData eventData)
    {
        isClicked = false;
        animatorHand.SetTrigger(triggerName3);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        animatorHand.SetTrigger(triggerName4);
    }
}
