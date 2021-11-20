using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // TODO figure out this readonly thing
    [ReadOnly]
    public int code = 1234;

    [ReadOnly] public int stage = 0; 
    [ReadOnly] public int lastStage = 0;

    [SerializeField] private TextMeshPro codeText;
    
    // Start is called before the first frame update
    void Start()
    {
        code = Random.Range(1000, 9999);
        codeText.text = code.ToString();
    }

    public void NextStage()
    {
        if (stage >= lastStage)
            return;
        stage++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
