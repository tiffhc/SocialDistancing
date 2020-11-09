using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropControl : MonoBehaviour, IDropHandler
{
    public GameObject animationSlot;
    public Sprite chessGame;
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        //eventData.pointerDrag.transform.position = Draggable.originalPos;
        Debug.Log(eventData.pointerDrag.name);
        if (eventData.pointerDrag.name == "Chessboard")
        {
            disableChar("mom");
            disableChar("dad");
            disableChar("daughter");
            disableChar("son");
            animationSlot.SetActive(true);
            animationSlot.GetComponent<Image>().sprite = chessGame;
        }
        
    }

    void disableChar(string character)
    {
        if (character != "dad")
        {
            GameObject.Find(character).GetComponent<Image>().enabled = false;
        }
        string char_bubble = character + "_bubble";
        GameObject.Find(char_bubble).GetComponent<Image>().enabled = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
