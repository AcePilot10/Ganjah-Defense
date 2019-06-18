using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

public class SceneBuilderWindow : EditorWindow {

    [MenuItem("Window/Scene Builder")]
    public static void ShowWindow()
    {
        GetWindow<SceneBuilderWindow>("Scene Builder");
    }

    private void OnGUI()
    {
        GUIStyle headerStyle = new GUIStyle();
        headerStyle.fontSize = 30;
        headerStyle.alignment = TextAnchor.MiddleCenter;
        headerStyle.normal.textColor = Color.blue;
        headerStyle.border = new RectOffset(5, 5, 5, 5);

        GUILayout.Label("Managers", headerStyle);
        DrawManagers();

        GUILayout.Label("UI", headerStyle);
        DrawUI();

        GUILayout.Label("Stash", headerStyle);
        DrawStash();
    }

    private void DrawManagers()
    {
        ManagerHolder[] managers = new ManagerHolder[]
        {
            new ManagerHolder()
            {
                ManagerLabel = "Level Manager",
                ManagerObject = FindObjectOfType<LevelManager>(),
                ManagerType = typeof(LevelManager)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Enemy Spawner",
                ManagerObject = FindObjectOfType<EnemySpawner>(),
                ManagerType = typeof(EnemySpawner)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Currency Manager",
                ManagerObject = FindObjectOfType<CurrencyManager>(),
                ManagerType = typeof(CurrencyManager)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Navigation Manager",
                ManagerObject = FindObjectOfType<NavigationManager>(),
                ManagerType = typeof(NavigationManager)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Selection Manager",
                ManagerObject = FindObjectOfType<SelectionManager>(),
                ManagerType = typeof(SelectionManager)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Camera View Manage",
                ManagerObject = FindObjectOfType<CameraViewManager>(),
                ManagerType = typeof(CameraViewManager)
            },
        };

        foreach (ManagerHolder manager in managers)
        {

            string result;
            Color backgroundColor;
            GUIStyle style = new GUIStyle();

            GUILayout.BeginHorizontal();

            if (manager.ManagerObject != null)
            {
                result = "OKAY";
                backgroundColor = Color.green;
            }
            else
            {
                result = "NOT FOUND";
                backgroundColor = Color.red;
            }

            style.alignment = TextAnchor.MiddleLeft;
            style.fontSize = 15;
            style.margin = new RectOffset(0, 0, 5, 5);
            style.normal.textColor = backgroundColor;
            style.wordWrap = true;

            GUILayout.Label(manager.ManagerLabel + " : " + result, style);

            GUILayout.EndHorizontal();
        }
    }

    private void DrawUI()
    {
        ManagerHolder[] managers = new ManagerHolder[]
        {
            new ManagerHolder()
            {
                ManagerLabel = "Notification Manager",
                ManagerObject = FindObjectOfType<NotificationManager>(),
                ManagerType = typeof(NotificationManager)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Notification Text",
                ManagerObject = FindObjectOfType<NotificationText>(),
                ManagerType = typeof(NotificationText)
            },
            new ManagerHolder()
            {
                ManagerLabel = "Notification Popup Manager",
                ManagerObject = FindObjectOfType<NotificationImageManager>(),
                ManagerType = typeof(NotificationImageManager)
            }
        };

        foreach (var manager in managers)
        {
            string result;
            Color backgroundColor;
            GUIStyle style = new GUIStyle();

            if (manager.ManagerObject != null)
            {
                result = "OKAY";
                backgroundColor = Color.green;
            }
            else
            {
                result = "NOT FOUND";
                backgroundColor = Color.red;
            }

            style.alignment = TextAnchor.MiddleLeft;
            style.fontSize = 15;
            style.margin = new RectOffset(0, 0, 5, 5);
            style.normal.textColor = backgroundColor;
            style.wordWrap = true;

            GUILayout.Label(manager.ManagerLabel + " : " + result, style);
        }
    }

    private void DrawStash()
    {
        Stash stash = FindObjectOfType<Stash>();

        string result;
        Color backgroundColor;
        GUIStyle style = new GUIStyle();

        if (stash != null)
        {
            result = "OKAY";
            backgroundColor = Color.green;
        }
        else
        {
            result = "NOT FOUND";
            backgroundColor = Color.red;
        }
        style.alignment = TextAnchor.MiddleLeft;
        style.fontSize = 15;
        style.margin = new RectOffset(0, 0, 5, 5);
        style.normal.textColor = backgroundColor;
        style.wordWrap = true;

        GUILayout.Label("Stash : " + result, style);
    }

    public class ManagerHolder
    {
        public System.Object ManagerObject { get; set; }
        public Type ManagerType { get; set; }
        public string ManagerLabel { get; set; }
    }
}