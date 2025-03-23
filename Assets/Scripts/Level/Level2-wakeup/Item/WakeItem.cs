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
        // 每帧增加时间
        timer += Time.deltaTime;

        // 每经过0.01秒，增加数值
        if (timer >= 0.01f)
        {
            WakeUpModel.Instance.FrequencyTime += 0.01f; // 数值增加0.01
            timer = 0f;     // 重置计时器
        }
        if (WakeUpModel.Instance.FrequencyTime > 1f) // 每秒钟计算一次点击频率
        {
            // 重置计时器
            WakeUpModel.Instance.FrequencyTime = 0f;
            WakeUpModel.Instance.clickModel = 0f;
        }
        // 打印当前值（可以移除此行）
        Debug.Log("当前数值: " + WakeUpModel.Instance.FrequencyTime);
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
        Debug.Log("点击");
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
