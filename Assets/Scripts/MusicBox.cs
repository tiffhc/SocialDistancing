using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource theme;
    public AudioClip maintheme;
    public AudioClip hotpot; 
  
    // Start is called before the first frame update
    void Start()
    {
        theme = this.GetComponent<AudioSource>();

        theme.loop = true;
        theme.PlayOneShot(maintheme); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
