using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseInfoBox : MonoBehaviour {

    public static DefenseInfoBox instance;

    public Transform contentHolder;
    public GameObject statObject;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowInfo(Defense defense)
    {
        ClearInfo();
        foreach (var stat in defense.Stats)
        {
            GameObject obj = Instantiate(statObject) as GameObject;
            DefenseInfoHolder info = obj.GetComponent<DefenseInfoHolder>();
            info.statText.text = stat.Name + " : " + stat.Value;

            if (stat.upgradeValue.Length == stat.currentUpgrade)
            {
                info.upgradeButton.gameObject.SetActive(false);
            }
            else
            {
                info.upgradeButton.onClick.AddListener(() =>
                {
                    UpgradeButtonClicked(defense, stat);
                });
            }
            obj.transform.parent = contentHolder;
            obj.transform.localScale = Vector3.one;
        }
        gameObject.SetActive(true);
    }

    public void UpgradeButtonClicked(Defense defense, DefenseStat stat)
    {
        UpgradeWindow.instance.ShowUpgrade(stat, defense, 5);
    }

    private void ClearInfo()
    {
        foreach (Transform child in contentHolder)
        {
            Destroy(child.gameObject);
        }
    }

    public void HideInfo()
    {
        ClearInfo();
        gameObject.SetActive(false);
    }
}