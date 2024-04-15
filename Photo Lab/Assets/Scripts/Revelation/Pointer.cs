using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{ 
    public string colName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       colName = collision.gameObject.name;
    }
}
