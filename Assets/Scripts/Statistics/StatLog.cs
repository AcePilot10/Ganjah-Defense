using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StatLog : MonoBehaviour
{

    private TextWriter textWriter;

    private void OnEnable()
    {
        Application.logMessageReceived += OnLog; 
    }

    private void OnDisable()
    {
        if (textWriter != null)
        {
            textWriter.Close();
        }
        Application.logMessageReceived -= OnLog;       
    }

    private void OnLog(string message, string stackTrace, LogType type)
    {
        WriteToFile(message);
    }

    public void InitNewStatFile()
    {
        if (textWriter != null)
        {
            textWriter.Close();
        }
        string id = System.Guid.NewGuid().ToString();
        string path = "Assets/Bin/Logs/" + id + ".txt";
        File.Create(path).Dispose();
        textWriter = new StreamWriter(path);
        Debug.Log("Created new stat log file. Id: " + id);
    }

    public void WriteToFile(string text)
    {
        if (textWriter != null)
        {
            textWriter.WriteLine(text);
        }
    }
}