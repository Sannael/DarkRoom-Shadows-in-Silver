using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    List<Vector3> positions = new List<Vector3>();
    public GameObject lineRenderPrefab;
    private LineRenderer currentLineRenderer;
    private List<LineRenderer> myLineInstances = new List<LineRenderer>();

    public GameObject brushCursor;
    public bool canDrawm;

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrawm)
        {
            Draw(eventData);
        }
    }

    public void CreateLineWithSamePoint(PointerEventData eventData)
    {
        currentLineRenderer = Instantiate(lineRenderPrefab).GetComponent<LineRenderer>();
        currentLineRenderer.SetPosition(0, new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y, 0));
        currentLineRenderer.SetPosition(1, new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y, 0));
        myLineInstances.Add(currentLineRenderer);


    }

    [ContextMenu("Clear Instances")]
    public void ClearInstances()
    {
        foreach(var item in myLineInstances)
        {
            Destroy(item.gameObject);
        }

        positions.Clear();
        myLineInstances.Clear();
    }
    public void UpdateLinePosition(PointerEventData eventData)
    {
        currentLineRenderer.positionCount = currentLineRenderer.positionCount + 1;
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount -1, new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y, 0));
        CreateLineWithSamePoint(eventData);
    }

    public void Draw(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.isValid == true)
        {
            if(currentLineRenderer == null)
            {
                CreateLineWithSamePoint(eventData);
            }
            else
            {
                UpdateLinePosition(eventData);
            }


            positions.Add(eventData.pointerCurrentRaycast.worldPosition);
        }
    }

    private void OnDrawGizmos()
    {
        foreach(var pos in positions)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(pos, 0.15f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrawm)
        {
            currentLineRenderer = null;
            brushCursor.GetComponent<Image>().enabled = true;
            // Cursor.visible = false;
            //CursorScript.cursorInstace.ChangeCursor("BrushClick");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        brushCursor.GetComponent<Image>().enabled = false;
        //Cursor.visible = true;
        //CursorScript.cursorInstace.ChangeCursor("Brush");
    }
}
