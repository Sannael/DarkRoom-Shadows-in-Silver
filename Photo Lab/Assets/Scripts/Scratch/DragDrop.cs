using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectT;
    private CanvasGroup canvasGroup;
    public GameObject desk;
    public GameObject photoBorderHover;
    private Canvas canvas;
    private PlayerScript ps;
    private void Awake()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        canvas = GetComponentInParent<Canvas>();
        rectT = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        desk.GetComponent<DropLocation>().Border(false);

    }
    private void OnEnable()
    {
        photoBorderHover.GetComponent<Image>().enabled = true; 

        rectT.anchoredPosition = new Vector2(0, -25);
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        photoBorderHover.GetComponent<Image>().enabled = false;


        desk.GetComponent<DropLocation>().Border(true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectT.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        photoBorderHover.GetComponent<Image>().enabled = true;

        desk.GetComponent<DropLocation>().Border(false);
        rectT.anchoredPosition = new Vector2(0, -25);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
