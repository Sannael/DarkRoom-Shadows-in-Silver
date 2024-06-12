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
    public DragDrop dragDropScript;

    private PlayerScript ps;
    private void OnEnable()
    {
        photoLoc.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        ps.canMove = false;
        photoSprite = ps.photoSprite;
        photoVertical = ps.photoVertical;
        if (ps.photoStage == 6)
        {
            dragDropScript.enabled = true;
            dragDropScript.photoBorderHover.GetComponent<Image>().enabled = false;
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
            dragDropScript.enabled = false;
            photoLoc.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            photoLoc.GetComponent<Image>().sprite = noPhoto;
            photoLoc.GetComponent<RectTransform>().sizeDelta = new Vector2(194, 248);
        }
    }

    private void OnDisable()
    {
        ps.canMove = true;
        dragDropScript.photoBorderHover.GetComponent<Image>().enabled = false;
    }
}
