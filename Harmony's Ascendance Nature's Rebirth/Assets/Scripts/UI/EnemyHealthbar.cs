using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    public FloatVariable enemyHealth;
    public Camera screen;
    void Update()
    {
        transform.LookAt(screen.transform);
    }
}
