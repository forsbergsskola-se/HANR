using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Player.UseSkills;
using TMPro;
using UltimateClean;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class SkillUI : MonoBehaviour
{
    private UsableItems usableItems;
    private SkillsPressed skillPressed;
    private bool canClickUltiSkill = true;
    private CleanButton cb1;
    private CleanButton cb2;
    private CleanButton cbU;
    private bool skilListenersAdded = false;
    
    [SerializeField] private Image megaSkill;
    
    [SerializeField] private Sprite starterMega;
    
    [SerializeField] private GameObject megaSkillButton;
    
    [SerializeField] private TextMeshProUGUI megaSkillCDText;

    private Item item;
    
    void Start()
    {
        cbU = megaSkillButton.GetComponent<CleanButton>();
        usableItems = GameObject.FindWithTag("Player").GetComponent<UsableItems>();
        skillPressed = GameObject.FindWithTag("Player").GetComponent<SkillsPressed>();
        //Add them listeners!
        usableItems.startStaffEquipped.AddListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.AddListener(ShowFireSkills);
        usableItems.waterStaffEquipped.AddListener(ShowWaterSkills);
        
        Color color = megaSkill.color;
        color.a = 0f;
        megaSkill.color = color;
    }


    private void OnDestroy()
    {
        //Remove them listeners!
        usableItems.startStaffEquipped.RemoveListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.RemoveListener(ShowFireSkills);
        usableItems.waterStaffEquipped.RemoveListener(ShowWaterSkills);
        removeSkillListeners();
    }

    private void ShowStarterSkills(Item i)
    {
        if (skilListenersAdded)
        {
            removeSkillListeners();
        }
        item = i;
        megaSkill.sprite = starterMega;
        addSkillListeners();
        skilListenersAdded = true;
        canClickUltiSkill = true;
    }
    
    private void ShowFireSkills(Item i)
    {
        if (skilListenersAdded)
        {
            removeSkillListeners();
        }
        item = i;
        megaSkill.sprite = i.ultiSkill.icon;
        megaSkill.color = Color.red;
        addSkillListeners();
        skilListenersAdded = true;
        canClickUltiSkill = true;
    }

    private void ShowWaterSkills(Item i)
    {
        if (skilListenersAdded)
        {
            removeSkillListeners();
        }
        item = i;
        megaSkill.sprite = i.ultiSkill.icon;
        megaSkill.color = Color.blue;
        addSkillListeners();
        skilListenersAdded = true;
        canClickUltiSkill = true;
    }

    private void removeSkillListeners()
    {
        if (item != null)
        {
            if (item.ultiSkill != null)
            {
                item.ultiSkill.valueChanged.RemoveListener(cooldownHandlingUltiSkill);
            }
        }
    }

    
    private void addSkillListeners()
    {
        item.ultiSkill.valueChanged.AddListener(cooldownHandlingUltiSkill);
        skilListenersAdded = true;
    }
    
    private void Update()
    {
        if (canClickUltiSkill)
        {
            cbU.interactable = true;
            megaSkillCDText.gameObject.SetActive(false);
        }
        else
        {
            cbU.interactable = false;
            megaSkillCDText.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ultiSkiilPressed();
        }
    }

    public void ultiSkiilPressed()
    {
        if (canClickUltiSkill)
        {
            skillPressed.skillPressed.Invoke(item.ultiSkill);
        }
    }
    public void cooldownHandlingUltiSkill(int cd)
    {
        megaSkillCDText.text = cd.ToString();
        if (cd != 0)
        {
            canClickUltiSkill = false;
        }
        else
        {
            canClickUltiSkill = true;
        }
    }


}

