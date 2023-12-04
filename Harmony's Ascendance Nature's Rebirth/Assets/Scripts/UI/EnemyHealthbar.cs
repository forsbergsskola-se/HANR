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

    private Slider enemyHealthSlider;
    private float maxHealth;

    private void Awake()
    {
        SetUpSlider();
        enemyHealth.ValueChanged.AddListener(UpdateHealthBar);
    }

    private void Start()
    {

    }

    private void OnDestroy()
    {
        enemyHealth.ValueChanged.RemoveListener(UpdateHealthBar);
    }

    void Update()
    {
        transform.LookAt(screen.transform);
    }


    private void SetUpSlider()
    {
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = 100;
    }

private void UpdateHealthBar(float arg0)
    {
        
    }

    
}
