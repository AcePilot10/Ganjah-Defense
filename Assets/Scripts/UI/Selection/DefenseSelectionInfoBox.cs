using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DefenseSelectionInfoBox : MonoBehaviour
{

    public GameObject infoBox;
    public GameObject textPrefab;
    public Image iconObject;
    public Button placeButton;

    private void OnEnable()
    {
        //gameObject.SetActive(false);
    }

    public void InitInfo(DefenseContainer defense)
    {
        ClearInfo();
        iconObject.sprite = defense.icon;
        foreach (string info in defense.info)
        {
            GameObject text = Instantiate(textPrefab) as GameObject;
            text.GetComponent<InfoText>().text.text = info;
            text.transform.SetParent(infoBox.transform);
        }
        placeButton.onClick.RemoveAllListeners();
        placeButton.onClick.AddListener(() => PlaceDefense(defense));
        gameObject.SetActive(true);
    }

    public void PlaceDefense(DefenseContainer defense)
    {
        DefensePlacement.instance.BeginPlacingObject(defense);
        Hide();
    }

    private void ClearInfo()
    {
        foreach (Transform child in infoBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}