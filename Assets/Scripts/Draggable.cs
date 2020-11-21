using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransformObj;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector3 originalPos;
    private CanvasGroup canvasGroup;
    [SerializeField] private GameObject originalHierarchy;
    private GameObject draggingHierarchy;

    void Start()
    {
        rectTransformObj = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        draggingHierarchy = GameObject.Find("DraggingHierarchy");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("onpointerdown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("onbegindrag");
        //canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(draggingHierarchy.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("ondrag");
        //Debug.Log(rectTransformObj.anchoredPosition);
        rectTransformObj.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("onenddrag");
        //canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //Debug.Log(originalPos);
        rectTransformObj.anchoredPosition = originalPos;
        //Debug.Log(transform.position);
        transform.SetParent(originalHierarchy.transform);
    }

}
