using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlacement : MonoBehaviour {

    #region Singleton
    public static DefensePlacement instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Members
    public bool isPlacing = false;

    public Material redMaterial;
    public Material greenMaterial;

    public DefenseContainer[] containers;

    public float surfaceLevel;

    public AudioClip errorSound;
    public AudioClip placeSound;

    public DefenseSelectionInfoBox infoBoxObject;

    private DefenseContainer defenseToSpawn;
    private LineRenderer objectLine;
    private GameObject currentOutline;
    #endregion

    private void Update()
    {
        if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }

            if (Input.GetMouseButtonDown(1))
            {
                CancelPlacing();
            }
        }

        UpdateOutlinePosition();
    }

    #region Public Functions
    public void BeginPlacingObject(DefenseContainer defense)
    {
        isPlacing = true;
        currentOutline = Instantiate(defense.outlineObject) as GameObject;
        defenseToSpawn = defense;
    }

    public void CancelPlacing()
    {
        if (isPlacing)
        {
            Destroy(currentOutline);
            isPlacing = false;
        }
    }

    public void ShowInfo(DefenseContainer defense)
    {
        infoBoxObject.InitInfo(defense);
        infoBoxObject.ShowInfo();
    }
    #endregion

    #region Helpers
    private void PlaceObject()
    {
        if (CanPlaceAtPosition())
        {
            Vector3 spawnPos = currentOutline.transform.position;
            spawnPos.y = surfaceLevel;
            Destroy(currentOutline);

            GameObject defense = Instantiate(defenseToSpawn.defensePrefab) as GameObject;
            defense.transform.position = spawnPos;
            defense.transform.parent = GameObject.FindGameObjectWithTag("Defense Bin").transform;

            AudioManager.instance.PlayAudio(placeSound);

            isPlacing = false;
        }
        else
        {
            Debug.Log("Couldn't place at that position!");
            AudioManager.instance.PlayAudio(errorSound);
        }
    }

    private void UpdateOutlinePosition()
    {
        if (!isPlacing) return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Map")
            {
                Vector3 spawnPos = new Vector3(hit.point.x, hit.point.y + surfaceLevel, hit.point.z);
                currentOutline.transform.position = spawnPos;
                if (CanPlaceAtPosition())
                {
                    SetRendererColor(1);
                }
                else
                {
                    SetRendererColor(2);
                }
            }
        }
    }

    private void SetRendererColor(int color)
    {
        MeshRenderer[] renderers = currentOutline.GetComponent<PlacementVisualizerReference>().renderers;
        Material material = null;
        switch (color)
        {
            case 1:
                material = greenMaterial;
                break;
            case 2:
                material = redMaterial;
                break;
        }
        foreach (Renderer renderer in renderers)
        {
            renderer.material = material;
        }
    }

    private bool CanPlaceAtPosition()
    {
        Vector3 pos = currentOutline.transform.position;
        int texture = PlacementUtil.GetMainTexture(pos);
        if (texture == defenseToSpawn.placeableTextureIndex)
        {
            return true;
        }
        else
            return false;
    }
    #endregion
}