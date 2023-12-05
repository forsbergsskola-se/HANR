using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public FloatVariable enemyHealth;
    public Camera screen;
    public Slider enemyHealthSlider;

    private void Awake()
    {
        SetUpSlider();
        enemyHealth.ValueChanged.AddListener(UpdateHealthBar);
    }

    private void OnDestroy()
    {
        enemyHealth.ValueChanged.RemoveListener(UpdateHealthBar);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - screen.transform.position);
        //transform.LookAt(screen.transform);
    }


    private void SetUpSlider()
    {
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = 100;
        UpdateHealthBar(100f);
        enemyHealth.setValue(100f);
    }

    private void UpdateHealthBar(float value)
    {
        enemyHealthSlider.value = value;
    }
}
