using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class OpeningCrate : MonoBehaviour
{
    public GameObject [] itemInside = new GameObject [3];
    public Quest quest;

    [SerializeField] private Instructions instructions;

    private void Start()
    {
        instructions = FindObjectOfType<Instructions>().GetComponent<Instructions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instructions.gameObject.SetActive(true);
            instructions.buttonInput.Invoke("Interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instructions.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.G) && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.CollectingCrate)
        {
            for (int slot = 0; slot < 4; slot++)
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
            if(quest.currentWaterStaffState == Quest.WaterStaffQuestLine.CollectingCrate) //To not retrigger same quest-objective 
                quest.questProgression.Invoke(3); //State goes to next (FindingRiverByRangerArea)
        }
    }
}
