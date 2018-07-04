using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Defense Container")]
public class DefenseContainer : ScriptableObject {

    public GameObject defensePrefab;
    public string defenseName;
    public int placeableTextureIndex;
    public GameObject outlineObject;
    public string[] info;
    public Sprite icon;

}