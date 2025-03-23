using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using level1model;
public class RelayControl : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            // 在2D环境下使用ScreenPointToRay时，仍然是获取鼠标位置的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);  // 使用Physics2D.Raycast进行2D射线检测

            // 如果射线击中某个物体
            if (hit.collider != null)
            {
                // 判断点击的物体是否有特定的标签（"CatItemTag"为例）
                if (hit.collider.CompareTag("CatItemTag") && hit.collider.gameObject.activeInHierarchy)
                {
                    // 如果点击的是带有特定Tag的物体，且物体未被禁用
                    ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
                else
                {
                    // 如果点击的是其他物体
                    Debug.Log("Miss，time +5");
                    Level1Model.Instance.time += 5f;
                }
            }
            else
            {
                // 没有点击任何物体，认为点击空白区域
                Debug.Log("Miss，time +5");
                Level1Model.Instance.time += 5f;
            }
        }
    }
}