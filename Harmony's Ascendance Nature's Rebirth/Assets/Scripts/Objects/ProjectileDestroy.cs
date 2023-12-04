using System;
using UnityEngine;

namespace Objects
{
    public class ProjectileDestroy : MonoBehaviour
    {
        private GameObject player;
        private float playerAttackRange = 15f;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if (Vector3.Distance(player.transform.position,this.transform.position) > playerAttackRange * 1.5f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}