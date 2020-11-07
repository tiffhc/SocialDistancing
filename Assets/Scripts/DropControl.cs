using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropControl : MonoBehaviour, IDropHandler
{
    public Sprite chessGame;
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
