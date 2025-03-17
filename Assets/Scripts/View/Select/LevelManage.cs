using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View.Select
{
    public class LevelManage : MonoBehaviour
    {
        private static LevelManage _instant;
        public static LevelManage Instant => _instant;
        private void Awake()
        {
            if (_instant != null)
            {
                Debug.LogError("重复LevelManager");
                Destroy(this);
            }
            else
            {
                _instant = this;
            }
        }
        public int LevelCount = 10;
        private int _newLevel = 0;



    }
}