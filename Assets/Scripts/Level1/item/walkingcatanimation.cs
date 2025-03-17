using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingcatanimation : Catdisappear
{
    [Header("物体引用配置")]
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    [Header("时间参数")]
    [Tooltip("基础间隔时间")]
    public float baseInterval = 0.5f;
    [Tooltip("最后物体停留时间")]
    public float finalStayDuration = 3f;

    void Update()
    {
        //第一阶段：检测物体1是否被显示
        if (IsObject1Active())
        {
            if (!Catdisappear.OnPointerClick()) 
            {
                StartCoroutine(SequenceRoutine());
            }
        }
    }

    IEnumerator SequenceRoutine()
    {
      
       
        yield return new WaitForSeconds(baseInterval);

        // 第二阶段：切换物体1->物体2
        ToggleObject(object1, false);
        ToggleObject(object2, true);
        yield return new WaitForSeconds(baseInterval);

        // 第三阶段：切换物体2->物体3
        ToggleObject(object2, false);
        ToggleObject(object3, true);
        yield return new WaitForSeconds(baseInterval);

        // 第四阶段：切换物体3->物体4
        ToggleObject(object3, false);
        ToggleObject(object4, true);

        // 最后等待并隐藏物体4
        yield return new WaitForSeconds(finalStayDuration);
        ToggleObject(object4, false);
    }

    public bool IsObject1Active()
    {
        return object1.activeSelf;
    }

        void ToggleObject(GameObject target, bool state)
    {
        if (target != null)
        {
            target.SetActive(state);
        }
       
    }
}
