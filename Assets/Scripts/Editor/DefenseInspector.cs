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
        /**
        PropertyInfo[] properties = defense.GetType().GetProperties();
        //List<DefenseStat> stats = fields.ToList().Where(x => typeof(DefenseStat).IsAssignableFrom(x.PropertyType));

        var query = from properties in properties.GetTypes()
                    from property in type.GetProperties()
                    where typeof(MyType).IsAssignableFrom(property.PropertyType)
                    select new { Type = type, Property = property };


        GUILayout.Label("Stats");
        foreach (FieldInfo statField in defenseFields)
        {
            DefenseStat stat = statField.GetValue(typeof(DefenseStat)) as DefenseStat;
            GUILayout.Label(stat.Name);
        }
        */
        /**
        List<FieldInfo> fieldList = new List<FieldInfo>();
        foreach (FieldInfo field in fields)
        {
            fieldList.Add(field);
        }

        List<DefenseStat> stats = new List<DefenseStat>();
        fieldList.ForEach(x => 
        {
            DefenseStat stat = x.GetValue(typeof(DefenseStat)) as DefenseStat;
            stats.Add(stat);
        });

        GUILayout.Label("Stats");
        foreach (DefenseStat stat in stats)
        {
            GUILayout.TextField("Stat");
        }
        */


        //base.DrawDefaultInspector();

        //    List<FieldInfo> fields = new List<FieldInfo>();
        //    fields = defense.GetType().GetFields().ToList();
        //    tab = GUILayout.Toolbar(tab, new string[] { "Stats", "General", "Other" });
        //    switch (tab)
        //    {
        //        case 0:
        //            List<FieldInfo> stats = new List<FieldInfo>();
        //            foreach (var field in fields)
        //            {
        //                object obj = field.GetValue(defense);
        //                if (obj is DefenseStat)
        //                {
        //                    stats.Add(field);
        //                }
        //            }

        //            foreach (var stat in stats)
        //            {
        //                DefenseStat defenseStat = stat.GetValue(defense) as DefenseStat;
        //                GUILayout.BeginHorizontal();
        //                GUILayout.Label(defenseStat.Name);
        //                //EditorGUILayout.ObjectField(defenseStat, typeof(DefenseStat));

        //                // defenseStat = EditorGUILayout.ObjectField(defenseStat.Name, defenseStat, typeof(DefenseStat), false) as DefenseStat;

        //                //defenseStat = EditorGUILayout.ObjectField(defenseStat, typeof(DefenseStat), false) as DefenseStat;

        //               //defenseStat = EditorGUILayout.PropertyField(")

        //                //float value = EditorGUILayout.FloatField(defenseStat.Value);
        //                //float currentValue = defenseStat.Value;
        //                //defenseStat.Value = EditorGUILayout.FloatField(currentValue);
        //                GUILayout.EndHorizontal();
        //            }
        //            break;
        //        case 1:
        //            base.DrawDefaultInspector();
        //            break;
        //        case 2:
        //            base.DrawDefaultInspector();
        //            break;
        //    }
        base.DrawDefaultInspector();
    }
}

//[CustomPropertyDrawer(typeof(DefenseStat))]
//public class DefenseStatPropertyDrawer : PropertyDrawer
//{
//    //public override VisualElement CreatePropertyGUI(SerializedProperty property)
//    //{
//    //    // Create property container element.
//    //    var container = new VisualElement();

//    //    // Create property fields.
//    //    var nameField = new PropertyField(property.FindPropertyRelative("Name"));
//    //    var valueField = new PropertyField(property.FindPropertyRelative("Value"));
//    //    var upgradeValuesField = new PropertyField(property.FindPropertyRelative("upgradeValue"), "Fancy Name");

//    //    // Add fields to the container.
//    //    container.Add(nameField);
//    //    container.Add(valueField);
//    //    container.Add(upgradeValuesField);

//    //    return container;
//    //}

//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        return 16f * 2;
//    }

//    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
//    {
//        var nameProperty = property.FindPropertyRelative("Name");
//        var valueProperty = property.FindPropertyRelative("Value");

//        EditorGUIUtility.wideMode = true;
//        EditorGUIUtility.labelWidth = 70;
//        rect.height /= 2;

//        nameProperty.stringValue = EditorGUI.TextField(rect, "Name", nameProperty.stringValue);
//        //positionProperty.vector3Value = EditorGUI.Vector3Field(rect, "Position", positionProperty.vector3Value);
//        rect.y += rect.height;
//        valueProperty.floatValue = EditorGUI.FloatField(rect, "Value", valueProperty.floatValue);
//        //normalProperty.vector3Value = EditorGUI.Vector3Field(rect, "Normal", normalProperty.vector3Value);



//    }
//}