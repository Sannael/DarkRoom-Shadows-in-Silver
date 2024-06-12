using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CursorScript : MonoBehaviour
{
    public static CursorScript cursorInstace;

    public Texture2D cursorIdle, cursorSelect, brushCursor, brushClick;
    public  Vector2 idleHotSpot = new Vector2(9, 3),
        selectHotSpot = new Vector2(11, 1),
        brushSpot = new Vector2(6,640),
        brushClickSpot = new Vector2(30,610);

    public void Awake()
    {
        cursorInstace = this;
    }
    public  void ChangeCursor(string mode)
    {
        switch (mode)
        {
            case "Idle":
                Cursor.SetCursor(cursorIdle, idleHotSpot, CursorMode.Auto);
                break;

            case "Select":
                Cursor.SetCursor(cursorSelect, selectHotSpot, CursorMode.Auto);
                break;
            case "Brush":
                Cursor.SetCursor(brushCursor, brushSpot, CursorMode.Auto);
                break;
            case "BrushClick":
                Cursor.SetCursor(brushClick, brushClickSpot, CursorMode.Auto);
                break;
        }
    }

}
