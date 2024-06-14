using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreUSurePnl : MonoBehaviour
{
    private void OnDisable()
    {
        this.GetComponent<Animator>().SetTrigger("Idle");
    }
}
