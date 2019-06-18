using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Defense Container")]
public class DefenseContainer : ScriptableObject {

    public GameObject defensePrefab;
    public string defenseName;
    public List<int> placeableTextureIndexes;
    public GameObject outlineObject;
    public string[] info;
    public Sprite icon;
    public float price;
    public Vector3 placeOffset;
}