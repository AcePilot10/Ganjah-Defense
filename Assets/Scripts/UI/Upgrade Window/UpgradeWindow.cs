using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : DraggableWindow {

    public static UpgradeWindow instance;

    public Button upgradeButton;
    public Transform contentParent;
    public UpgradeContentHolder upgradeScreenPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void ShowUpgrade(DefenseStat stat, Defense defense, float addValue)
    {
        ClearContent();
        ShowWindow();

        GameObject obj = Instantiate(upgradeScreenPrefab.gameObject) as GameObject;
        obj.transform.parent = contentParent;
        UpgradeContentHolder content = obj.GetComponent<UpgradeContentHolder>();
        content.transform.localScale = Vector3.one;

        content.nameText.text = stat.Name;
        content.currentText.text = stat.Value.ToString();
        content.upgradedText.text = stat.upgradeValue[stat.currentUpgrade].ToString();
        content.costText.text = stat.upgradeValue[stat.currentUpgrade].cost.ToString();

        upgradeButton.onClick.AddListener(() => 
        {
            if (FindObjectOfType<CurrencyManager>().Weed >= stat.upgradeValue[stat.currentUpgrade].cost)
            {
                stat.Value = stat.upgradeValue[stat.currentUpgrade].value;
                stat.currentUpgrade++;
                DefenseInfoBox.instance.ShowInfo(defense);
                HideWindow();
            }
        });
    }

    public override void HideWindow()
    {
        ClearContent();
        gameObject.SetActive(false);
    }

    private void ClearContent()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        upgradeButton.onClick.RemoveAllListeners();
    }

}