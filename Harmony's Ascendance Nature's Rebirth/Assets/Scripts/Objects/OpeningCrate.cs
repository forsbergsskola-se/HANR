using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpeningCrate : MonoBehaviour
{
    public GameObject [] itemInside = new GameObject [3];
    public QuestUI questUI;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            
            for (int slot = 0; slot < 3; slot++)
            {
                float randomPositionX = Random.Range(1f, 5f); //To spawn items in close random positions
                float randomPositionZ = Random.Range(1f, 5f);
                
                Vector3 setPosition = transform.position;
                Quaternion setRotation = transform.rotation;
                Vector3 offset = setRotation * new Vector3(randomPositionX, 0f, randomPositionZ);
                Vector3 newPosition = setPosition + offset;
                
                Instantiate(itemInside[slot], newPosition, setRotation);
            }
            Destroy(gameObject);
            questUI.questProgression.Invoke(4);
        }
    }
}
