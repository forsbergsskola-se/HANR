using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestUI : MonoBehaviour
{
    public UnityEvent quest;
    public UnityEvent questProgression;

    public QuestLine questLine;
    
    
    void Start()
    {
        quest.AddListener(questGuide);
    }

    private void OnDestroy()
    {
        quest.RemoveListener(questGuide);
    }

    private void questGuide()
    {
        
    }
    
    private void Progression()
    {
        
    }
}
