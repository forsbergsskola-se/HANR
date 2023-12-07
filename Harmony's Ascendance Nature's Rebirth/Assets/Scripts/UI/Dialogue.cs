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
        druidToRanger.AddListener(DruidTalkingRanger);
    }

    private void OnDestroy()
    {
        druidToRanger.RemoveListener(DruidTalkingRanger);
    }

    void DruidTalkingRanger()
    {
        chating.text = "Ranger: I'm distraught, the water in these woods are vital for all life but has been curated by darkness and is slowly killing everything that is dependent on it.";
    }
}
