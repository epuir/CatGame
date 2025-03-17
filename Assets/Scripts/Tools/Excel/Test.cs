using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Tools.Excel
{
    public class Test:MonoBehaviour
    {
        private void Start()
        {
            var t=  Application.streamingAssetsPath;
            var d =  Directory.GetParent(Application.dataPath);
            string path = Path.Combine(t, "Text.csv");
            CSV.LoadFile( "D:\\game creat\\CatGame\\Excel\\Test.csv\\", ( s) =>
            {
                foreach (var VARIABLE in s)
                {
                    Debug.LogError("/n");
                    foreach (var VA in VARIABLE)
                    {
                        Debug.Log(VA);
                    }
                }
            });
            
        }
    }
}