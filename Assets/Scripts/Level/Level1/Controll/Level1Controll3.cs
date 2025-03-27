using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using level1model;

public class Level1Controll3 : MonoBehaviour
{
    public List<GameObject> childObjects = new List<GameObject>();


    private StageConfig[] stages = new StageConfig[]
    {
        new StageConfig(30, 1, 3),
        new StageConfig(60, 3, 3),
        new StageConfig(60, 4, 3)
    };

    void Start()
    {
        
        InitializeObjects();
        StartCoroutine(StageManager());
    }
    
    void InitializeObjects()
    {
        foreach (var obj in childObjects)
        {
            obj.SetActive(false);
        }
    }
    
    IEnumerator StageManager()
    {
        yield return new WaitForSeconds(30); 
        foreach (var stage in stages)
        {
            Level1Model.Instance.time = 0;
            while (Level1Model.Instance.time < stage.duration)
            {
                // 等待间隔时间
                yield return new WaitForSeconds(5);

                // 随机选择对象
                List<GameObject> selected = GetRandomObjects(stage.objectsToShow);

                // 显示并隐藏对象
                StartCoroutine(ShowAndHide(selected, stage.visibleDuration));

                Level1Model.Instance.time += 5;
            }
        }
    }

    List<GameObject> GetRandomObjects(int count)
    {
        List<GameObject> candidates = new List<GameObject>(childObjects);
        List<GameObject> selected = new List<GameObject>();

        for (int i = candidates.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = candidates[i];
            candidates[i] = candidates[randomIndex];
            candidates[randomIndex] = temp;
        }

        for (int i = 0; i < Mathf.Min(count, candidates.Count); i++)
        {
            selected.Add(candidates[i]);
        }
        return selected;
    }

    IEnumerator ShowAndHide(List<GameObject> objects, float duration)
    {
        // 显示对象
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }

        // 等待持续时间
        yield return new WaitForSeconds(duration);

        // 隐藏对象
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }


    [System.Serializable]
    private class StageConfig
    {
        public float duration;
        public int objectsToShow;
        public float visibleDuration;

        public StageConfig(float dur, int count, float visible)
        {
            duration = dur;
            objectsToShow = count;
            visibleDuration = visible;
        }
    }
}
