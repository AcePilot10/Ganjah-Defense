using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefenseInfoBox : DraggableWindow {

    public static DefenseInfoBox instance;

    public Transform contentHolder;
    public GameObject statObject;

    private ISelectable currentSelectable;

    private void Awake()
    {
        instance = this;
    }

    public void ShowInfo(Defense defense)
    {
        Debug.Log("Showing info for defense " + defense.name);
        currentSelectable = defense;
        ClearInfo();
        foreach (var stat in defense.Stats)
        {
            GameObject obj = Instantiate(statObject) as GameObject;
            DefenseInfoHolder info = obj.GetComponent<DefenseInfoHolder>();
            info.statText.text = stat.Name + " " + stat.Value;

            if (stat.upgradeValue.Count == stat.currentUpgrade)
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
        ShowWindow();
    }

    public void UpgradeButtonClicked(Defense defense, DefenseStat stat)
    {
        UpgradeWindow.instance.ShowUpgrade(stat, defense, 5);
    }

    public override void HideWindow()
    {
        ClearInfo();
        gameObject.SetActive(false);
    }

    private void ClearInfo()
    {
        foreach (Transform child in contentHolder)
        {
            Destroy(child.gameObject);
        }
    }

    public void DeleteDefense()
    {
        if (currentSelectable is IDestroyable)
        {
            ((IDestroyable)currentSelectable).Destroy();
        }
    }
}