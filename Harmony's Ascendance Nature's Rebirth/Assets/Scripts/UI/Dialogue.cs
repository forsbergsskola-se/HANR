using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public UnityEvent druidToRanger;
    public TMP_Text chating;
    private void Start()
    {   
        this.gameObject.SetActive(false);
        druidToRanger.AddListener(DruidTalkingRanger);
    }

    private void OnDestroy()
    {
        druidToRanger.RemoveListener(DruidTalkingRanger);
    }

    void DruidTalkingRanger()
    {
        GameObject.Find("PlayerUICanvas").SetActive(false);
        this.gameObject.SetActive(true);
        chating.text = "I'm distraught, the water in these woods are vital for all life but has been curated by darkness and is slowly killing everything that is dependent on it.";
    }
}
