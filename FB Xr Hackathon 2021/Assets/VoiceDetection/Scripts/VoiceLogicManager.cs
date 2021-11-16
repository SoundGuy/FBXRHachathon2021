using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoiceLogicManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ResponseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    public void HandleGreetings(string[] values)
    {
        int i = 0;
        foreach (  string val in values)
        {
            Debug.Log("values =" + i + " = " + values[i++]);    
        }
        
        ResponseText.text = "Oh, hello there.";
    }
}
