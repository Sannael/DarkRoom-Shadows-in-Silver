using NovaSamples.UIControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchBtns : MonoBehaviour
{
    public PlayerScript ps;
    public Button thisBtn;
    public Scratch sc;

    private void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        sc = GameObject.Find("Scratch").GetComponent<Scratch>();
        thisBtn = this.GetComponent<Button>();
    }


    public void Check()
    {
        Debug.Log("HIHI");
        if (ps.leftClick.action.IsInProgress()) 
        {
            Destroy(gameObject);
        }
        if (ps.leftClick.action.IsPressed()) 
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
         sc.photoRetCounts--;
    }
}
