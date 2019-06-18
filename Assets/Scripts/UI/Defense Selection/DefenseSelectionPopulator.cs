using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefenseSelectionPopulator : MonoBehaviour
{

    public GameObject defensePlaceButtonPrefab;
    public Transform contentParent;
    public DefenseSelectionInfoBox infoBox;

    private void OnEnable()
    {
        Populate();
    }

    //    public void Populate()
    //    {
    //        foreach (var defense in defenses)
    //        {
    //            GameObject buttonObject = Instantiate(defensePlaceButtonPrefab) as GameObject;
    //            TextMeshProUGUI text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
    //            text.text = defense.name;
    //            buttonObject.transform.parent = contentParent;

    //            Button btn = buttonObject.GetComponent<Button>();
    //            EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();

    //            DefensePlacement placementManager = FindObjectOfType<DefensePlacement>();

    //            btn.onClick.AddListener(() => placementManager.BeginPlacingObject(defense));

    //            EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
    //            pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
    //            //pointerEnterEntry.callback.AddListener((eventData) => placementManager.ShowInfo(defense));

    //            EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
    //            pointerExitEntry.eventID = EventTriggerType.PointerExit;
    //           // pointerExitEntry.callback.AddListener((eventData) => FindObjectOfType<DefenseSelectionInfoBox>().HideInfo());

    //            eventTrigger.triggers.Add(pointerEnterEntry);
    //            eventTrigger.triggers.Add(pointerExitEntry);
    //        }
    //    }
    //}

    private void Populate()
    {
        DefensePlacement defenseManager = FindObjectOfType<DefensePlacement>();
        var defenses = new List<DefenseContainer>();
        foreach (var defense in defenseManager.containers)
        {
            defenses.Add(defense);
        }

        defenses.Sort((a, b) => a.price.CompareTo(b.price));
        
        Debug.Log("Populating defense placement with " + defenseManager.containers.Length + " defenses");
        foreach (var defenseContainer in defenses)
        {
            GameObject btnObject = Instantiate(defensePlaceButtonPrefab) as GameObject;
            Button btn = btnObject.GetComponent<Button>();
            btn.onClick.AddListener(() => BeginPlacingDefense(defenseContainer));
            btn.onClick.AddListener(() => Debug.Log(defenseContainer.defenseName + " has been clicked"));
            btnObject.GetComponent<DefenseButtonData>().defense = defenseContainer;
            btnObject.GetComponent<Image>().sprite = defenseContainer.icon;
            btnObject.transform.SetParent(contentParent);
        }
    }

    private void BeginPlacingDefense(DefenseContainer container)
    {
        infoBox.InitInfo(container);
    }
}