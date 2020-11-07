using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool selected;

    void Update()
    {
        if (selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;               
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("onbegindrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ondrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onenddrag");
    }

}
