using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaralScript : MonoBehaviour
{
    public Sprite photoSprite;
    public bool photoVertical;
    public GameObject photoLoc; //local que vai ficar a foto

    private PlayerScript ps;
    private void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    private void OnEnable()
    {
        if (ps.photoStage == 6)
        {
            if (photoVertical)
            {
                photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 90, 0);
            }
            photoLoc.GetComponent<Image>().sprite = photoSprite;
        }
        else 
        {
            photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            photoLoc.GetComponent<Image>().sprite = null;
        }
    }
}
