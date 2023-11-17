using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int minY, maxY;
    public Transform target;
    [SerializeField]
    private bool canMove = false;
    [HideInInspector]
    public bool backToPos = false;
    void Update()
    {
        try { canMove = GameObject.Find("Player").GetComponent<PlayerScript>().canMove; }
        catch {}
        if (canMove)
        {
            if (target.position.y > minY && target.position.y < maxY)
            {
                transform.position = Vector2.Lerp(transform.position, target.position, 0.1f);
            }
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (backToPos)
        {
            transform.position = target.position;
        }
        
    }
}
