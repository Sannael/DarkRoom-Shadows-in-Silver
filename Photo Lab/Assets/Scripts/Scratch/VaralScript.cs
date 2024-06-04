using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaralScript : MonoBehaviour
{
    public Sprite photoSprite;
    public bool photoVertical;
    public GameObject photoLoc; //local que vai ficar a foto
    public Sprite noPhoto;

    private PlayerScript ps;
    private void OnEnable()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        photoSprite = ps.photoSprite;
        photoVertical = ps.photoVertical;
        if (ps.photoStage == 6)
        {
            if (photoVertical)
            {
                photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
                photoLoc.GetComponent<RectTransform>().sizeDelta = new Vector2(194, 248);
            }
            else
            {
                photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0.7f, 0.7f);
                photoLoc.GetComponent<RectTransform>().sizeDelta = new Vector2(248, 194);
            }
            photoLoc.GetComponent<Image>().sprite = photoSprite;
        }
        else 
        {
            photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            photoLoc.GetComponent<Image>().sprite = noPhoto;
            photoLoc.GetComponent<RectTransform>().sizeDelta = new Vector2(194, 248);
        }
    }
}
