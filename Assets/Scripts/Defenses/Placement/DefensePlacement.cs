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

    public GameObject outlineObject;

    public Material redMaterial;
    public Material greenMaterial;

    public DefenseContainer[] containers;

    public float surfaceLevel;

    private GameObject defenseToSpawn;
    private LineRenderer objectLine;
    private GameObject currentOutline;

    public int placeableTexture = 0;
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
        currentOutline = Instantiate(outlineObject) as GameObject;
        defenseToSpawn = defense.defensePrefab;
    }

    public void CancelPlacing()
    {
        if (isPlacing)
        {
            Destroy(currentOutline);
            isPlacing = false;
        }
    }
    #endregion

    #region Helpers
    private void PlaceObject()
    {
        if (CanPlaceAtPosition())
        {
            Vector3 spawnPos = currentOutline.transform.position;
            Destroy(currentOutline);

            GameObject defense = Instantiate(defenseToSpawn) as GameObject;
            defense.transform.position = spawnPos;
            //defense.transform.SetParent(holderObject.transform);

            isPlacing = false;
        }
        else
        {
            Debug.Log("Couldn't place at that position!");
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
                Renderer renderer = currentOutline.GetComponent<Renderer>();
                if (CanPlaceAtPosition())
                {
                    renderer.material = greenMaterial;
                }
                else
                {
                    renderer.material = redMaterial;
                }
            }
        }
    }

    private bool CanPlaceAtPosition()
    {
        Vector3 pos = currentOutline.transform.position;
        int texture = PlacementUtil.GetMainTexture(pos);
        if (texture == placeableTexture)
        {
            return true;
        }
        else
            return false;
    }
    #endregion
}