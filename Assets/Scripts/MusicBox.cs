using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource theme;
    public AudioClip maintheme;
    public AudioClip maintheme2;
    public AudioClip maintheme3;
    public AudioClip maintheme4; 
    public AudioClip hotpot; 
  
    // Start is called before the first frame update
    void Start()
    {
        theme = this.GetComponent<AudioSource>();

        theme.loop = true;
        theme.clip = maintheme;
        theme.Play(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
