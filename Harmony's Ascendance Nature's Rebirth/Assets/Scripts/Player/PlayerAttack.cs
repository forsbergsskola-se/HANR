using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void LateUpdate()
    {
        ClickCheck clickCheck = GetComponent<ClickCheck>();
        AttackEnemy(clickCheck.rayHit);
    }

    private void AttackEnemy(RaycastHit raycastHit)
    {
        Debug.Log("Enemy Hit");
    }
}
