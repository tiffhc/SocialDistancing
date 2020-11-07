using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransformObj;
    [SerializeField] private Canvas canvas;
    public static Vector3 originalPos;
    private CanvasGroup canvasGroup;

    void Start()
    {
        rectTransformObj = GetComponent<RectTransform>();
        originalPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("onpointerdown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("onbegindrag");
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ondrag");
        //Debug.Log(rectTransformObj.anchoredPosition);
        rectTransformObj.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onenddrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.position = originalPos;
    }

}
