using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

public class DefenseInspector : Editor {

    public Defense defense;

    private void OnEnable()
    {
        defense = target as Defense;
    }

    public override void OnInspectorGUI()
    {
        FieldInfo[] fields = defense.GetType().GetFields();
        //List<DefenseStat> stats = fields.ToList().Where(x => typeof(DefenseStat).IsAssignableFrom(x.PropertyType));
        List<FieldInfo> defenseFields = defense.GetType().GetFields()
            .Where(x => x.GetValue(typeof(DefenseStat)) != null).ToList();
        GUILayout.Label("Stats");
        foreach (FieldInfo statField in defenseFields)
        {
            GUILayout.Label(statField.Name);
        }
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
    }
}