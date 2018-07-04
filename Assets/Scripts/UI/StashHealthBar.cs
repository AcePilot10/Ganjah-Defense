using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StashHealthBar : MonoBehaviour {

    public Text healthText;
    public Slider healthSlider;

    private void Update()
    {
        Stash stash = FindObjectOfType<Stash>();
        healthText.text = stash.health + "%";
        healthSlider.value = stash.health;
    }
}