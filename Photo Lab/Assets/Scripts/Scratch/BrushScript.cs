using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushScript : MonoBehaviour
{
    public bool interactive;
    private bool canUse;
    public Scratch scratchScript;

    public Sprite normalSprite, interactiveSprite;
    private bool retIsEnable;

    private void Awake()
    {
        retIsEnable = false;
    }
    private void Update()
    {
        if (!interactive)
        {
            GetComponent<Image>().sprite = normalSprite;
            canUse = false;
        }
        else 
        {
            GetComponent<Image>().sprite = interactiveSprite;
            canUse = true;
            if (!retIsEnable)
            {
                //scratchScript.EnableRet();
                retIsEnable = true;
            }
            
        }
    }

    public void OnEnable()
    {
        GetComponent<Image>().enabled = true;
    }

    public void OnClick() 
    {
        if (canUse) 
        {
            GetComponent<Image>().enabled = false;
            interactive = false;
            scratchScript.EnableRet();
            //CursorScript.cursorInstace.ChangeCursor("Brush");
        }
    }

    public void ChangeCursor() 
    {
    
    } 
}
