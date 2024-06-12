using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropLocation : MonoBehaviour, IDropHandler
{
    public Sprite normalSprite, borderSprite;
    public GameObject varalPnl, scratchPnl;

    private void OnEnable()
    {
        Border(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("HH");
        if (eventData.pointerDrag != null)
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().photoStage++;
            OpenClosePnl(varalPnl, scratchPnl);
        }
    }
    public void OpenClosePnl(GameObject oPanel, GameObject cPanel)
    {
        oPanel.SetActive(false);
        cPanel.SetActive(true);

    }

    public void Border(bool border)
    {
        if (border)
        {
            GetComponent<Image>().sprite = borderSprite;
        }
        else 
        {
            GetComponent<Image>().sprite = normalSprite;
        }
    }
}
