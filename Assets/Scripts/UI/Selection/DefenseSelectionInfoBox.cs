using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseSelectionInfoBox : MonoBehaviour {

    public GameObject infoBox;
    public GameObject textPrefab;
    public Image iconObject;

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
    }

    private void ClearInfo()
    {
        foreach (Transform child in infoBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowInfo()
    {
        gameObject.SetActive(true);
    }

    public void HideInfo()
    {
        gameObject.SetActive(false);
    }
}