using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PrototypeStatisticsManager {

    private static string path = "Assets/Statistics/Stats.txt";

    public static void WriteToFile(string str)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(str);
        writer.Close();
    }

    [MenuItem("Statistics/Read File")]
    public static void ReadFile()
    {
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}