using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tools.Excel
{
    public static class CSV
    {
        public static int AllLine;

        public static void LoadFile(string filepath, Action<List<string[]>> a)
        {
            if (!File.Exists(filepath))
            {
                Debug.LogError(filepath + " no found");
                return;
            }

            StreamReader sr = null;
            try
            {
                Debug.LogError("开始");
                sr = File.OpenText(filepath);
                List<string[]> content = new List<string[]>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    content.Add(line.Split(',')); //csv格式
                }

                sr.Close();
                sr.Dispose();
                Debug.Log("Line：" + content.Count);
                AllLine = content.Count;
                a?.Invoke(content);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
