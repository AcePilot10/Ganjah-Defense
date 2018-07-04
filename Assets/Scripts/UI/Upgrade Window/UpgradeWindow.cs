using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour {

    public static UpgradeWindow instance;

    public Button upgradeButton;
    public Transform contentParent;
    public UpgradeContentHolder upgradeScreenPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowUpgrade(DefenseStat stat, Defense defense, float addValue)
    {
        gameObject.SetActive(true);
        ClearContent();

        GameObject obj = Instantiate(upgradeScreenPrefab.gameObject) as GameObject;
        obj.transform.parent = contentParent;
        UpgradeContentHolder content = obj.GetComponent<UpgradeContentHolder>();

        content.nameText.text = stat.Name;
        content.currentText.text = stat.Value.ToString();
        content.upgradedText.text = stat.upgradeValue[stat.currentUpgrade].ToString();

        upgradeButton.onClick.AddListener(() => 
        {
            stat.Value = stat.upgradeValue[stat.currentUpgrade];
            stat.currentUpgrade++;
            DefenseInfoBox.instance.ShowInfo(defense);
            HideWindow();
        });
    }

    private void ClearContent()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        upgradeButton.onClick.RemoveAllListeners();
    }

    public void HideWindow()
    {
        ClearContent();
        gameObject.SetActive(false);
    }
}