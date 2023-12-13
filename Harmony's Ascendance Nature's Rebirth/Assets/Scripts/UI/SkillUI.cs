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
    private bool canClickSkill1= true;
    private bool canClickSkill2= true;
    private bool canClickUltiSkill = true;
    private CleanButton cb1;
    private CleanButton cb2;
    private CleanButton cbU;
    private bool skilListenersAdded = false;
    
    [SerializeField] private Image megaSkill;
    [SerializeField] private Image smallSkill;
    [SerializeField] private Image small2Skill;
    
    [SerializeField] private Sprite starterMega;
    [SerializeField] private Sprite starterSmall;
    [SerializeField] private Sprite starterSmall2;
    
    [SerializeField] private GameObject megaSkillButton;
    [SerializeField] private GameObject skill1Button;
    [SerializeField] private GameObject skill2Button;
    
    [SerializeField] private TextMeshProUGUI megaSkillCDText;
    [SerializeField] private TextMeshProUGUI skill1CDText;
    [SerializeField] private TextMeshProUGUI skill2CDText;

    private Item item;
    
    void Start()
    {
        cb1 = skill1Button.GetComponent<CleanButton>();
        cb2 = skill2Button.GetComponent<CleanButton>();
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
        small2Skill.color = color;
        smallSkill.color = color;
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
        smallSkill.sprite = starterSmall;
        small2Skill.sprite = starterSmall2;
        addSkillListeners();
        skilListenersAdded = true;
        canClickSkill1= true;
        canClickSkill2= true;
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
        smallSkill.sprite = i.skill1.icon;
        small2Skill.sprite = i.skill2.icon;
        megaSkill.color = Color.red;
        addSkillListeners();
        skilListenersAdded = true;
        canClickSkill1= true;
        canClickSkill2= true;
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
        smallSkill.sprite = i.skill1.icon;
        small2Skill.sprite = i.skill2.icon;
        megaSkill.color = Color.blue;
        addSkillListeners();
        skilListenersAdded = true;
        canClickSkill1= true;
        canClickSkill2= true;
        canClickUltiSkill = true;
    }

    private void removeSkillListeners()
    {
        if (item != null)
        {
            if (item.skill1 != null)
            {
                item.skill1.valueChanged.RemoveListener(cooldownHandlingSkill1);
            }

            if (item.skill2 != null)
            {
                item.skill2.valueChanged.RemoveListener(cooldownHandlingSkill2);
            }

            if (item.ultiSkill != null)
            {
                item.ultiSkill.valueChanged.RemoveListener(cooldownHandlingUltiSkill);
            }
        }
    }

    
    private void addSkillListeners()
    {
        item.skill1.valueChanged.AddListener(cooldownHandlingSkill1);
        item.skill2.valueChanged.AddListener(cooldownHandlingSkill2);
        item.ultiSkill.valueChanged.AddListener(cooldownHandlingUltiSkill);
        skilListenersAdded = true;
    }
    
    private void Update()
    {
        if (canClickSkill1)
        {
            cb1.interactable = true;
            skill1CDText.gameObject.SetActive(false);
        }
        else
        {
            cb1.interactable = false;
            skill1CDText.gameObject.SetActive(true);
        }
        
        if (canClickSkill2)
        {
            cb2.interactable = true;
            skill2CDText.gameObject.SetActive(false);
        }
        else
        {
            cb2.interactable = false;
            skill2CDText.gameObject.SetActive(true);
        }
        
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
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            skill1Pressed();
        }  
        else if (Input.GetKeyDown(KeyCode.W))
        {
            skill2Pressed();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ultiSkiilPressed();
        }
    }

    public void skill1Pressed()
    {
        if (canClickSkill1)
        {
            skillPressed.skillPressed.Invoke(item.skill1);
        }
    }
    
    public void skill2Pressed()
    {
        if (canClickSkill2)
        {
            skillPressed.skillPressed.Invoke(item.skill2);
        }
    }
    
    public void ultiSkiilPressed()
    {
        if (canClickUltiSkill)
        {
            skillPressed.skillPressed.Invoke(item.ultiSkill);
        }
    }

    public void cooldownHandlingSkill1(int cd)
    {
        skill1CDText.text = cd.ToString();
        if (cd != 0)
        {
            canClickSkill1 = false;
        }
        else
        {
            canClickSkill1 = true;
        }
    }
    
    public void cooldownHandlingSkill2(int cd)
    {
        skill2CDText.text = cd.ToString();
        if (cd != 0)
        {
            canClickSkill2 = false;
        }
        else
        {
            canClickSkill2 = true;
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

