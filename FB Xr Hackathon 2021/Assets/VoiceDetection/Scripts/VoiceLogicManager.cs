using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VoiceLogicManager : MonoBehaviour
{

    [SerializeField] private UnityEvent onTalk;
    [SerializeField] private UnityEvent onStopTalking;
    
    [SerializeField] private UnityEvent onListening;
    [SerializeField] private UnityEvent onStopListening;


    [SerializeField] private bool isTalking = false;
    [SerializeField]private bool responded = false;

    [SerializeField] private ConverationLogic _conversationManager; 
    [SerializeField] private TextMeshProUGUI [] ResponseTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTalking()
    {
        onTalk.Invoke();
    }

    public void StopTalking()
    {
        onStopTalking.Invoke();
    }

    public void StartListening()
    {
        responded = false;
        onListening.Invoke();
        
    }

    public void StopListening()
    {
        onStopListening.Invoke();
        isTalking = false;
    }

    public void ToggleTalking()
    {
        isTalking = !isTalking;
        if (isTalking)  {
            StartTalking();
        } else {
            StopTalking();
        }
    }
       
    public void HandleGenericText(string[] values)
    {
        if (responded)
            return;
        string ouText = _conversationManager.HandleGenericText(values);
        SetText(ouText);
        responded = true;
    }

    
    public void HandleTesting(string[] values)
    {
        string ouText = _conversationManager.HandleTesting(values);
        SetText(ouText);
        responded = true;
    }

    
    public void HandleGreetings(string[] values)
    {
        string ouText = _conversationManager.HandleGreetings(values);
        SetText(ouText);
        responded = true;
    }
    
    public void HandleHelp(string[] values)
    {
        string ouText = _conversationManager.HandleHelp(values);
        SetText(ouText);
        responded = true;
    }
    
    public void HandleHelpFindingCode(string[] values)
    {
        string ouText = _conversationManager.HandleHelpFindingCode(values);
        SetText(ouText);
        responded = true;
    }
    public void HandleHelpStartingShip(string[] values)
    {
        string ouText = _conversationManager.HandleHelpStartingShip(values);
        SetText(ouText);
        responded = true;
    }
    
    public  void HandleCode(string[] values)
    {
        string ouText = _conversationManager.HandleCode(values);
        SetText(ouText);
        responded = true;
    }


    void SetText(String inText)
    {
        foreach (TextMeshProUGUI responseText in ResponseTexts)
        {
            responseText.text = inText;
        }
    }
}
