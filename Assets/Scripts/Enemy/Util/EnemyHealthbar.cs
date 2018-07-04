using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    private EnemyBase enemy;
    private Slider slider;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyBase>();
        slider = GetComponent<Slider>();
    }

    void Update ()
    {
        if (enemy == null || slider == null) return;
        slider.value = enemy.health;
	}
}