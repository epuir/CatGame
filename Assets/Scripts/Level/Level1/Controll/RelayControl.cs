using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using level1model;
public class RelayControl : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ������������
        {
            // ��2D������ʹ��ScreenPointToRayʱ����Ȼ�ǻ�ȡ���λ�õ�����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);  // ʹ��Physics2D.Raycast����2D���߼��

            // ������߻���ĳ������
            if (hit.collider != null)
            {
                // �жϵ���������Ƿ����ض��ı�ǩ��"CatItemTag"Ϊ����
                if (hit.collider.CompareTag("CatItemTag") && hit.collider.gameObject.activeInHierarchy)
                {
                    // ���������Ǵ����ض�Tag�����壬������δ������
                    ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
                else
                {
                    // ������������������
                    Debug.Log("Miss��time +5");
                    Level1Model.Instance.time += 5f;
                }
            }
            else
            {
                // û�е���κ����壬��Ϊ����հ�����
                Debug.Log("Miss��time +5");
                Level1Model.Instance.time += 5f;
            }
        }
    }
}