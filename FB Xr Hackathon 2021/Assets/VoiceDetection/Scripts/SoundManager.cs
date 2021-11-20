using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource _audioSource;
    // Start is called before the first frame update

    private int lastPlayed;

    public void PlayRandomSound()
    {
        _audioSource.PlayOneShot(PickRandomSound());
    }

    AudioClip PickRandomSound(){
        int rand = -1;
        while (rand == -1)
        {
            rand = Random.Range(0, sounds.Length);
            if (sounds.Length > 1 && rand == lastPlayed)
            {
                rand = -1;
            }
        }

        lastPlayed = rand;
        Debug.Log("Rand = " + rand);
        return sounds[rand];
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
