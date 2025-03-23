using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.EventSystems;

public class WakeItem : BaseItem
{
    public Animator animatorCat;
    public Animator animatorHand;
    public string triggerName1 = "SwitchAnimation1";
    public string triggerName2 = "SwitchAnimation2";
    public string triggerName3 = "SwitchAnimation3"; 
    public string triggerName4 = "SwitchAnimation4";
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.03f);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        animatorCat.SetTrigger(triggerName2);
        Debug.Log("µã»÷");
        delay();
        animatorCat.SetTrigger(triggerName1);
    }



    public override void OnPointerEnter(PointerEventData eventData)
    {
        animatorHand.SetTrigger(triggerName3);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        animatorHand.SetTrigger(triggerName4);
    }
}
