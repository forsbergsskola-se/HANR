using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CustomObjects;
using UnityEngine.Serialization;

public class UsableItems : MonoBehaviour
{
    private InventoryHolder inventoryHolder;

    public UnityEvent<Item> startStaffEquipped;
    public UnityEvent<Item> fireStaffEquipped;
    public UnityEvent<Item> waterStaffEquipped; 
    public UnityEvent UpdateUsedItem;
    
    [SerializeField] private Item defaultItem;
    
    public FloatVariable playerHealth;
    public FloatVariable playerExperiance;
    public FloatVariable playerMagic;
    public IntVariable playerLevel;
    private Item itemInSlot;
    
    void Start()
    {
        inventoryHolder = GetComponent<InventoryHolder>();
    }



    void Update()
    {
        CheckInput();
    }

    void CheckInput() //To use/equip item
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryHolder.Items[0] != defaultItem)
        {
            
            CheckSlot(0);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryHolder.Items[1] != defaultItem)
        {
            
            CheckSlot(1);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryHolder.Items[2] != defaultItem)
        {
            
            CheckSlot(2);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryHolder.Items[3] != defaultItem)
        {
          
            CheckSlot(3);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryHolder.Items[4] != defaultItem)
        {
        
            CheckSlot(4);

        }
    }



    void CheckSlot(int slotIndex)
    {
        itemInSlot = inventoryHolder.Items[slotIndex];
        if (itemInSlot != defaultItem)
        {
            if (itemInSlot.itemClass == "Weapon")
            {
                if (itemInSlot.itemID == "Starter Staff")
                {
                    startStaffEquipped.Invoke(itemInSlot);
                }

                if (itemInSlot.itemID == "Fire Staff")
                {
                    Debug.Log("Fire Weapon");
                    fireStaffEquipped.Invoke(itemInSlot);
                }

                if (itemInSlot.itemID == "Water Staff")
                {
                    Debug.Log("Water Weapon");
                    waterStaffEquipped.Invoke(itemInSlot);
                }

            }

            if (itemInSlot.itemClass == "Consumable") //When using potions
            {
                if (itemInSlot.itemID == "Potion Health")
                {
                    
                    //Add health to player
                    float newHealth = itemInSlot.itemStat + playerHealth.getValue();
                    playerHealth.setValue(newHealth);
                    SFX.SoundManager.PlaySound("Heal");
                    inventoryHolder.Items[slotIndex] = defaultItem;
                    UpdateUsedItem.Invoke();

                }
                else if (itemInSlot.itemID == "Potion Magic")
                {

                    //Add Magic to player
                    float newMagic = itemInSlot.itemStat + playerMagic.getValue();
                    playerMagic.setValue(newMagic);
                    SFX.SoundManager.PlaySound("Mana & EXP");
                    inventoryHolder.Items[slotIndex] = defaultItem;
                    UpdateUsedItem.Invoke();

                }
                else if (itemInSlot.itemID == "Potion Exp")
                {

                    //Add exp to player
                    float newExp = itemInSlot.itemStat + playerExperiance.getValue();
                    playerExperiance.setValue(newExp);
                    SFX.SoundManager.PlaySound("Mana & EXP");
                    inventoryHolder.Items[slotIndex] = defaultItem;
                    UpdateUsedItem.Invoke();
                }
            }
        }
    }
}

