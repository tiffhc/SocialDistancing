using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative : MonoBehaviour
{
    public Animator speechbubble;
    public Text text;
    public string[] gameStartNarrative;
    public string[] chessNarrative;
    public string[] travellingNarrative;
    public string[] TVNarrative;
    public string[] teaNarrative;
    public string[] danceNarrative;
    public string[] studyNarrative;
    public string[] snackNarrative;
    public string[] catNarrative;
    public string[] hotpotNarrative;
    public string[] plantNarrative;
    private int narrativeCounter = 0;
    private float WaitTime = 3f;
    private float animationTime = 1f;
    //private bool gameStart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameStart()
    {
        displayNarrative(gameStartNarrative);
    }

    public void resetCounter()
    {
        narrativeCounter = 0;
    }

    public void displayNarrative(string[] narrative)
    {
        //Debug.Log("playing narrative");

        if (narrativeCounter < narrative.Length)
        {
            if (narrativeCounter == 0)
            {
                StopAllCoroutines();
                //Debug.Log(narrative.Length);
                text.text = narrative[narrativeCounter];
                speechbubble.SetBool("fadein", true);
                StartCoroutine(waitNarrative(WaitTime, narrative));
            }
            else
            {
                //Debug.Log("Displaying " + narrativeCounter);
                StartCoroutine(waitNarrative(WaitTime, narrative));
            }
           
        }

    }

    public void fadeOutNarrative(string[] narrative)
    {
        speechbubble.SetBool("fadein", false);
        //only fade in if not last line of dialogue
        if (narrativeCounter < narrative.Length - 1)
        {
            StartCoroutine(waitAnimation(animationTime, narrative));
        }
    }

    IEnumerator waitNarrative(float waitTime, string[] narrative)
    {
        yield return new WaitForSeconds(waitTime);
        fadeOutNarrative(narrative); 
    }

    IEnumerator waitAnimation(float waitTime, string[] narrative)
    {
        yield return new WaitForSeconds(waitTime);
        narrativeCounter++;
        text.text = narrative[narrativeCounter];

        speechbubble.SetBool("fadein", true);
        if (narrativeCounter < narrative.Length)
        {
            Debug.Log("Narrative still there " + narrativeCounter);
            displayNarrative(narrative);
        }
    }

}
