using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool outlineIsSelected = false;

    public Material redMaterial;
    public Material greenMaterial;

    public DefenseContainer[] containers;

    public float surfaceLevel;

    public AudioClip errorSound;
    public AudioClip placeSound;

    public DefenseSelectionInfoBox infoBoxObject;

    public GameObject placeButtonObject;
    public Button cancelButton;

    public Transform outlineSpawnPos;

    private DefenseContainer defenseToSpawn;
    private LineRenderer objectLine;
    private GameObject currentOutline;
    #endregion

    void OnEnable()
    {
       //CurrencyManager.instance.OnCurrencyChange += OnCurrencyChange;
       cancelButton.onClick.AddListener(() => { CancelPlacing(); });
    }

    private void OnDisable()
    {
        CurrencyManager.instance.OnCurrencyChange -= OnCurrencyChange;
    }

    private void LateUpdate()
    {
//#if UNITY_EDITOR
//        if (isPlacing)
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                PlaceObject();
//            }

//            if (Input.GetMouseButtonDown(1))
//            {
//                CancelPlacing();
//            }
//        }
//#endif
        if (outlineIsSelected)
        {
            UpdateOutlinePosition();
        }
    }

    #region Public Functions
    public void BeginPlacingObject(DefenseContainer defense)
    {
        float price = defense.price;
        if (CurrencyManager.instance.Weed >= price)
        {
            if (isPlacing)
            {
                CancelPlacing();
            }
            isPlacing = true;
            currentOutline = Instantiate(defense.outlineObject) as GameObject;
            defenseToSpawn = defense;
            if (defenseToSpawn.defensePrefab.GetComponent<TargetDefense>() != null &&
                currentOutline.GetComponent<OutlineRangeVisualizer>() != null)
            {
                float range = defenseToSpawn.defensePrefab.GetComponent<TargetDefense>().rangeStat.Value;
                currentOutline.GetComponent<OutlineRangeVisualizer>().DrawRange(range);
            }
            currentOutline.transform.position = outlineSpawnPos.position;
            placeButtonObject.SetActive(true);
            cancelButton.gameObject.SetActive(true);
            Debug.Log("Began placing defense");
        }
        else
        {
            NotificationManager.instance.ShowMessage("Not enough weed!");
        }
    }

    public void SetIsMoving(bool isMoving)
    {
        outlineIsSelected = isMoving;
    }

    public void CancelPlacing()
    {
        if (isPlacing)
        {
            Destroy(currentOutline);
            isPlacing = false;
            placeButtonObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }
    }

    public void PlaceObject()
    {
        if (CanPlaceAtPosition())
        {
            Vector3 spawnPos = currentOutline.transform.position;
            spawnPos.y = surfaceLevel;
            Destroy(currentOutline);

            GameObject defense = Instantiate(defenseToSpawn.defensePrefab) as GameObject;
            defense.transform.position = spawnPos + defenseToSpawn.placeOffset;

            if (GameObject.FindGameObjectWithTag("Defense Bin") != null) defense.transform.parent = GameObject.FindGameObjectWithTag("Defense Bin").transform;

            if (placeSound != null) AudioManager.instance.PlayAudio(placeSound);

            defense.GetComponent<Defense>().InvokeOnPlace();

            CurrencyManager.instance.Weed -= defenseToSpawn.price;

            isPlacing = false;
            placeButtonObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Couldn't place at that position!");
            if (errorSound != null) AudioManager.instance.PlayAudio(errorSound);
        }
    }
    #endregion

    #region Helpers


    private void UpdateOutlinePosition()
    {
        if (!isPlacing && outlineIsSelected) return;
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
        if (defenseToSpawn.placeableTextureIndexes.Contains(texture))
        {
            return true;
        }
        else
            return false;
    }
    #endregion

    private void OnCurrencyChange()
    {
        //FindObjectOfType<ButtonColorChanger>().SetColor(Color.red);
    }
}