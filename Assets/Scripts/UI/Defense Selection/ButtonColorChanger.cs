using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour {

    public Transform buttonHolder;

    private void Start()
    {
        CurrencyManager.instance.OnCurrencyChange += OnCurrencyChange;    
    }

    private void OnCurrencyChange()
    {
        foreach (Transform child in buttonHolder)
        {
            DefenseButtonData data = child.GetComponent<DefenseButtonData>();
            DefenseContainer defense = data.defense;
            float currentCurrency = CurrencyManager.instance.Weed;
            Button btn = child.GetComponent<Button>();
            ColorBlock colors = btn.colors;
            if (defense.price > currentCurrency)
            {
                colors.normalColor = Color.gray;
                btn.interactable = false;
            }
            else
            {
                colors.normalColor = Color.white;
                btn.interactable = true;
            }
            btn.colors = colors;
        }
    }
}