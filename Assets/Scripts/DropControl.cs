using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropControl : MonoBehaviour, IDropHandler
{
    //public GameObject animationSlot;
    public GameObject chessEvent;
    public GameObject catEvent;
    public GameObject danceEvent;
    public GameObject hotpotEvent;
    public GameObject plantEvent;
    public GameObject remoteEvent;
    public GameObject snackEvent;
    public GameObject studyingEvent;
    public GameObject teaEvent;
    public GameObject travellingEvent;

    //public Sprite TVOff;
    //public Sprite TVOn;
    //public Image TV;

    public Animator TV;

    private bool[] charactersInvolvedBool;
    private string[] charactersInvolved;

    private IEnumerator coroutine;
    private GameObject droppedObj;
    private string droppedObjName;
    private GameObject eventObj;
    private static float eventTime = 5.0f;
    private bool rightBubble;
    [SerializeField] private string bubbleType;


    //Audio 
    AudioSource sfx;
    public AudioClip good;
    public AudioClip bad;

    //Theme audios

    public MusicBox m;

    public static int numEventsUnlocked = 0;

    bool theme1 = true;
    bool theme2 = false;
    bool theme3 = false;
    bool theme4 = false; 


    void Start()
    {
        rightBubble = false;
        // grandma, mom, dad, daughter, son
        charactersInvolved = new string[] {"grandma", "mom", "dad", "daughter", "son"};
        charactersInvolvedBool = new bool[] {false, false, false, false, false};

        sfx = this.GetComponent<AudioSource>(); 
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        //eventData.pointerDrag.transform.position = Draggable.originalPos;
        Debug.Log(eventData.pointerDrag.name);
        droppedObj = eventData.pointerDrag;
        droppedObjName = droppedObj.name;

        if (droppedObjName == "Chessboard")
        {
            if (bubbleType != "grandma")
            {
                rightBubble = true;
                charactersInvolvedBool = new bool[] { false, true, true, true, true };
                disableObj("Study");
                eventObj = chessEvent;
            }
            

        }

        else if (droppedObjName == "Cat")
        {
            if (bubbleType == "grandma" | bubbleType == "dad")
            {
                charactersInvolvedBool = new bool[] { true, false, true, false, false };
                rightBubble = true;
                eventObj = catEvent;
            }
        }

        else if (droppedObjName == "Speaker")
        {
            if (bubbleType != "grandma")
            {
                rightBubble = true;
                charactersInvolvedBool = new bool[] { false, true, true, true, true };
                eventObj = danceEvent;
            }

        }

        else if (droppedObjName == "Hotpot")
        {
            //Audio for hotpot scene
            m.theme.clip = m.hotpot;
            m.theme.Play(); 

            rightBubble = true;
            charactersInvolvedBool = new bool[] { true, true, true, true, true };
            disableObj("Hotpot");
            disableObj("Study");
            eventObj = hotpotEvent;
        }

        else if (droppedObjName == "Plant")
        {
            if (bubbleType == "grandma" | bubbleType == "mom")
            {
                charactersInvolvedBool = new bool[] { true, true, false, false, false };
                disableObj("Remote");
                rightBubble = true;
                eventObj = plantEvent;
            }
        }

        else if (droppedObjName == "Remote")
        {
            if (bubbleType == "daughter"| bubbleType == "son")
            {
                charactersInvolvedBool = new bool[] { false, false, false, true, true };
                //TV.sprite = TVOff;
                TV.SetBool("tvOff", true);
                rightBubble = true;
                eventObj = remoteEvent;
            }
        }

        else if (droppedObjName == "Snack")
        {
            if (bubbleType != "mom" && bubbleType != "daughter")
            {
                charactersInvolvedBool = new bool[] { true, false, true, false, true };
                rightBubble = true;
                eventObj = snackEvent;
            }
            
        }

        else if (droppedObjName == "Study")
        {
            if (bubbleType == "daughter"| bubbleType == "son")
            {
                charactersInvolvedBool = new bool[] { false, false, false, true, true };
                disableObj("Teaset");
                rightBubble = true;
                eventObj = studyingEvent;
            }
            
        }

        else if (droppedObjName == "Teaset")
        {
            if (bubbleType == "grandma" | bubbleType == "daughter")
            {
                charactersInvolvedBool = new bool[] { true, false, false, true, false };
                rightBubble = true;
                eventObj = teaEvent;
            }
            
        }
        
        else if (droppedObjName == "Traveling")
        {
            if (bubbleType != "grandma" && bubbleType != "dad")
            {
                
                charactersInvolvedBool = new bool[] { false, true, false, true, true };
                disableObj("Remote");
                rightBubble = true;
                eventObj = travellingEvent;

            }
            
        }


        if (rightBubble)
        {
            sfx.PlayOneShot(good);
            numEventsUnlocked++; //increment the number of events found 
            Debug.Log(numEventsUnlocked); 

            if (droppedObjName != "Speaker" && droppedObjName != "Snack")
            {
                droppedObj.GetComponent<CanvasGroup>().alpha = 0;
            }
            updateCharacter();
            //Debug.Log("right bubble");
            eventObj.SetActive(true);
            coroutine = Wait(eventTime, eventObj);
            StartCoroutine(coroutine);
        }
        else
        {
            sfx.PlayOneShot(bad);
        }

    }

    void updateCharacter()
    {
        for (int i=0; i<charactersInvolvedBool.Length; i++)
        {
            if (charactersInvolvedBool[i])
            {
                disableChar(charactersInvolved[i]);
            }
        }
    }

    private IEnumerator Wait(float waitTime, GameObject eventObj)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        droppedObj.GetComponent<CanvasGroup>().alpha = 1;
        droppedObj.GetComponent<CanvasGroup>().interactable = false;
        droppedObj.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (droppedObjName == "Remote")
        {
            //TV.sprite = TVOn;
            TV.SetBool("tvOff", false);
        }
        eventObj.SetActive(false);
        rightBubble = false;
    }

    void disableObj(string obj)
    {
        GameObject.Find(obj).GetComponent<Image>().enabled = false;
        coroutine = WaitEnablingObj(eventTime, obj);
        StartCoroutine(coroutine);
    }

    void disableChar(string character)
    {
        if (character != "dad")
        {
            GameObject.Find(character).GetComponent<Image>().enabled = false;
            float alphaVar = 0.25f;
            //Find the grayscale image and disable them too
            if (character == "son" | character == "daughter")
            {
                alphaVar = 0.17f;
            }
            GameObject.Find(character).transform.GetChild(0).GetComponent<CanvasGroup>().alpha -= alphaVar;
            //GameObject.Find(character).GetComponentInChildren<Image>().enabled = false;
            GameObject.Find(character).transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        string char_bubble = character + "_bubble";
        GameObject.Find(char_bubble).GetComponent<Image>().enabled = false;

        coroutine = WaitEnabling(eventTime, character);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitEnabling(float waitTime,  string character)
    {
        yield return new WaitForSeconds(waitTime);
        if (character != "dad")
        {
            GameObject.Find(character).GetComponent<Image>().enabled = true;
            GameObject.Find(character).transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        string char_bubble = character + "_bubble";
        GameObject.Find(char_bubble).GetComponent<Image>().enabled = true;
    }

    private IEnumerator WaitEnablingObj(float waitTime, string obj)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Find(obj).GetComponent<Image>().enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if((numEventsUnlocked >= 3)&&(numEventsUnlocked <= 5))
        {
            //Debug.Log("Playing theme2");
            if (!theme2)
            {
                //Debug.Log("Playing theme2222");
                m.theme.clip = m.maintheme2;
                m.theme.Play();
                theme2 = true;
                theme1 = false; 
            }
        }

        if((numEventsUnlocked >= 6)&&(numEventsUnlocked <= 7))
        {
            if(!theme3)
            {
                m.theme.clip = m.maintheme3;
                m.theme.Play();

                theme3 = true; 
                theme2 = false; 
            }
        }

        if((numEventsUnlocked >= 8)&&(numEventsUnlocked <= 10))
        {
            if(!theme4)
            {
                m.theme.clip = m.maintheme4;
                m.theme.Play();

                theme3 = false;
                theme4 = true; 
            }
        }
    }
    
}
