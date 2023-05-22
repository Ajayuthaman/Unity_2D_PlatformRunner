using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        //keep this object even when go to new scene
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroying duplicate Game Objects
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
        
    }
}
