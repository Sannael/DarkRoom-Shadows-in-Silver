using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int minY, maxY;
    public Transform target;
    void Update()
    {
        if(target.position.y > minY && target.position.y < maxY)
        {
            transform.position = Vector2.Lerp(transform.position , target.position, 0.1f);
        }
    }
}
