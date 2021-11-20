using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObjectEnabler : MonoBehaviour
{

    [SerializeField] private GameObject[] editorEnabler;
    [SerializeField] private GameObject[] vrDisabler;
    // Start is called before the first frame update
    void Start()
    {
        // enable these when you're in editor
        #if UNITY_EDITOR
        foreach (GameObject gameObject in editorEnabler)
        {
            gameObject.SetActive(true);
        }
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
