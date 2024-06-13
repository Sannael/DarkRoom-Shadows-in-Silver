using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePnls : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip closePanelsSound;

    public void PlaySound() 
    {
        Sounds.instance.PlaySingle(closePanelsSound);
    }
}
