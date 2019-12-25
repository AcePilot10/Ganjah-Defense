using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(TurretBase))]
public class DefenseInspector : Editor {

    public Defense defense;
    int tab = 0;

    private void OnEnable()
    {
        defense = target as Defense;
    }

    public override void OnInspectorGUI()
    {
        //List<FieldInfo> fields = defense.GetType().GetFields().ToList();
        //tab = GUILayout.Toolbar(tab, new string[] { "Stats", "General", "Other" });
        //switch (tab)
        //{
        //    case 0:
        //        foreach (var field in fields)
        //        {
        //            object obj = field.GetValue(defense);
        //            if (obj is DefenseStat)
        //            {
        //                DefenseStat stat = obj as DefenseStat;
        //                string fieldName = field.Name;
        //                var prop = serializedObject.FindProperty(fieldName);
        //                EditorGUILayout.PropertyField(prop);
        //            }
        //        }
        //        break;
        //    case 1:
        //        base.DrawDefaultInspector();
        //        break;
        //    case 2:
        //        base.DrawDefaultInspector();
        //        break;
        //}
       base.DrawDefaultInspector();
    }
}

//[CustomPropertyDrawer(typeof(DefenseStat))]
//public class DefenseStatPropertyDrawer : PropertyDrawer
//{
//    private bool showInfo = false;

//    //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    //{
//    //    return 16f * 2;
//    //}

//    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
//    {
//        //rect.height /= 2;
//        //rect.y += rect.height * 2;

//        EditorGUI.BeginProperty(rect, label, property);

//        showInfo = EditorGUILayout.Foldout(showInfo, fieldInfo.Name + " info");
//        if (showInfo)
//        {
//            var nameProperty =  property.FindPropertyRelative("_name");
//            var valueProperty = property.FindPropertyRelative("_value");

//            //EditorGUIUtility.wideMode = true;
//            //EditorGUIUtility.labelWidth = 70;
//            //rect.height /= 2;
//            //rect.height *= 2;

//            nameProperty.stringValue = EditorGUI.TextField(rect, "Name", nameProperty.stringValue);
//            Debug.Log("Name is: " + nameProperty.stringValue);
//            rect.y += rect.height;
//            valueProperty.floatValue = EditorGUI.FloatField(rect, "Value", valueProperty.floatValue);
//        }

//        EditorGUI.EndProperty();
//    }
//}