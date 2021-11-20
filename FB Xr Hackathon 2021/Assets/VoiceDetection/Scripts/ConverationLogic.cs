using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConverationLogic : MonoBehaviour
{
    [SerializeField]  private GameLogic _gameLogic;
    [SerializeField]  private SoundManager _soundManager;
    [SerializeField]  private Animator _AlienAnimator;
    // TOdo - move these to scriptable objects?
    [SerializeField] private string[] greetingResponses;
    [SerializeField] private string[] testingResponses;
    [SerializeField] private string[] genericTextResponses;

    [SerializeField] private string[] maybeYouCanHelpMe;
    
    [SerializeField] private string[] codeCorrectResponses;
    [SerializeField] private string[] codeInorrectResponses;
    
    // make this a multiple array
    [SerializeField] private string[] helpPerStage;
    [SerializeField] private string[] stageNames;
    
    private int prevRand = -1;
    private int howManyGreetings = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // TODO  find  _gameLogic or show error.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DebugValues(string[] values)
    {
        int i = 0;
        foreach (  string val in values)
        {
            Debug.Log("values =" + i + " = " + values[i++]);    
        }
    }
   

    string pickAStringInRandom(string[] strings)
    {
        int rand = -1;
        while (rand == -1)
        {
            rand = Random.Range(0, strings.Length);
            if (strings.Length > 1 && rand == prevRand)
            {
                rand = -1;
            }
        }

        prevRand = rand;
        Debug.Log("Rand = " + rand);
        return strings[rand];
    }

    void DoInAllResponses(string[] values)
    {
        DebugValues(values);    
        _soundManager.PlayRandomSound();
        _AlienAnimator.Play("BoraxTalk");
    }
    public string HandleGreetings(string[] values)
    {
        DoInAllResponses(values);    
        string ouText = pickAStringInRandom(greetingResponses);
        if (howManyGreetings++ > 1)
        {
            // todo: prefixed
            ouText += "\n" + pickAStringInRandom(maybeYouCanHelpMe) + "\n" + GetHelpForStage();
        }
        return ouText;
    }

    public string GetHelpForStage()
    {
        if (_gameLogic.stage == 0)
        {
            
            _gameLogic.NextStage();
            return  helpPerStage[_gameLogic.stage-1];       
        }
        return  helpPerStage[_gameLogic.stage];
        
    }
    
    public string HandleHelp(string[] values)
    {
        DoInAllResponses(values);    
        string ouText =  GetHelpForStage();
        return ouText;
    }
    
    
    
    public string HandleHelpStartingShip(string[] values)
    {
        DoInAllResponses(values);
        _gameLogic.stage = 1; // disgusting and buggy
        string ouText =  GetHelpForStage();
        return ouText;
    }
    
    public string HandleHelpFindingCode(string[] values)
    {
        DoInAllResponses(values);
        _gameLogic.stage = 2; // disgusting and buggy
        string ouText =  GetHelpForStage();
        return ouText;
    }
    

    public string HandleTesting(string[] values)
    {
        DoInAllResponses(values);    
        string ouText = pickAStringInRandom(testingResponses);
        return ouText;
    }
    
    public string HandleGenericText(string[] values)
    {
        DoInAllResponses(values);    
        string ouText =  pickAStringInRandom(genericTextResponses) + (values.Length>0 ? values[0] : "");
        return ouText;
    }
    
    
    public string HandleCode(string[] values)
    {
        string ouText = "";
        DoInAllResponses(values);
        int inCode = Int32.Parse(values[0]);
        if (inCode == _gameLogic.code)
        {
            // success
             ouText = pickAStringInRandom(codeCorrectResponses);
            _gameLogic.stage = 3;
        }
        else
        {
            ouText = pickAStringInRandom(codeInorrectResponses);
        }
        
        return ouText;
    }

    
}
