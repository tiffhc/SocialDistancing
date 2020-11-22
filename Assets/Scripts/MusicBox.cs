using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    AudioSource[] audios; //[0] is for themes, [1] is for sfx
    public AudioSource sfx; 
   // public AudioClip mainTheme;
    public AudioClip goodSound;
    public AudioClip badSound; 

    // Start is called before the first frame update
    void Start()
    {
        audios = this.GetComponents<AudioSource>();
        audios[0].loop = true;
        audios[0].Play();
        sfx = audios[1]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
