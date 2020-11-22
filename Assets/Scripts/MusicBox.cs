using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    AudioSource[] audios; 
    public AudioSource theme1;
    public AudioSource theme2;
    public AudioSource theme3;
    public AudioSource theme4; 

    public AudioClip maintheme;
    public AudioClip maintheme2;
    public AudioClip maintheme3;
    public AudioClip maintheme4; 
    public AudioClip hotpot; 
  
    // Start is called before the first frame update
    void Start()
    {
        audios = this.GetComponents<AudioSource>();

        //set up parallel music track

        theme1 = audios[0];
        theme2 = audios[1];
        theme3 = audios[2];
        theme4 = audios[3];

        theme1.loop = true;
        theme2.loop = true;
        theme3.loop = true;
        theme4.loop = true;

        theme1.volume = 0.2f;

        //the rest of the audios are at volume 0; 
        theme2.volume = 0.0f;
        theme3.volume = 0.0f;
        theme4.volume = 0.0f;

        //assign the themes to each element

        theme1.clip = maintheme;
        theme2.clip = maintheme2;
        theme3.clip = maintheme3;
        theme4.clip = maintheme4;

        //play all themes

        theme1.Play();
        theme2.Play();
        theme3.Play();
        theme4.Play(); 

        /*theme.loop = true;
        theme.clip = maintheme;
        theme.Play(); **/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
