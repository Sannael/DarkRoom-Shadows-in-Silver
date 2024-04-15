using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevelationScript : MonoBehaviour
{
    public GameObject[] part;
    public GameObject[] tray;
    public GameObject[] paper;
    public GameObject[] photo;
    public GameObject[] clamp;
    public GameObject[] bar;
    public GameObject[] chemical;
    public GameObject[] blur;
   
    [Header("Photo Area")]
    public Sprite photoSprite;
    public bool photoVertical;
    public int photoStage;
    public int lastStage;
    public Color32 photoColor;

    private PlayerScript ps;
    private Button buttonclose;

    private void OnEnable()
    {
        bar[2].SetActive(false);
        buttonclose = this.GetComponent<ButtonsPanelClose>().btnClose;
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        photoSprite = ps.photoSprite;
        photoVertical = ps.photoVertical;
        photoStage = ps.photoStage;
        photoColor = ps.photoColor;

        if(photoStage == 3)
        { 
            buttonclose.GetComponent<RectTransform>().anchoredPosition = new Vector3(1950, -472, 0);
            photo[0].GetComponent<Image>().sprite = photoSprite;
            photo[0].GetComponent<Image>().color = photoColor;
            paper[0].SetActive(true);
            bar[0].SetActive(true);

            foreach (GameObject f in photo)
            {
                float rot = f.GetComponent<RectTransform>().localRotation.z;
                ChangePhotoRect(f, photoVertical, rot);
            }
        }
        else
        {
            paper[0].SetActive(false);
            bar[0].SetActive(false);
            buttonclose.GetComponent<RectTransform>().anchoredPosition = new Vector3(-860, -472, 0);
        }
    }

    public void ChangeOpacPhoto(int amount)
    {
        int res = photoColor.a + amount;
        if(res > 255)
        {
            photoColor.a = 255;
        }
        else if(res < 0)
        {
            photoColor.a = 0;
        }
        else
        {
            photoColor.a += (byte)amount;
        }
        photo[0].GetComponent<Image>().color = photoColor;
        photoColor = photo[0].GetComponent<Image>().color;

    }
    public void ChangePhotoRect(GameObject photoObj, bool vert, float rot)
    {
        if (vert)
        {
            photoObj.GetComponent<RectTransform>().sizeDelta = new Vector2(406, 608);

            if(rot != 0)
            {
                 photoObj.GetComponent<RectTransform>().Rotate(0, 0, 90);
            }
        }
        else
        {
            photoObj.GetComponent<RectTransform>().sizeDelta = new Vector2(608, 406);

            if (rot == 0)
            {
                 photoObj.GetComponent<RectTransform>().Rotate(0, 0, -90);
            }
        }
    }
    public void LastStageSettings()
    {
        paper[1].SetActive(true);
        this.GetComponent<Animator>().SetTrigger("Move2");
        paper[1].GetComponent<Animator>().SetTrigger("Move");

        bar[1].SetActive(false);
        blur[1].SetActive(false);
    }

    public void Update()
    {
        if(photoStage == 3)
        {
            paper[1].SetActive(false);
            if(photoColor.a == 255)
            {
                photoStage =4;
                bar[0].SetActive(false);
                blur[0].SetActive(false);
                this.GetComponent<Animator>().SetTrigger("Move1");
                paper[0].GetComponent<Animator>().SetTrigger("Move");

            }
            else
            {
                bar[0].SetActive(true);
                blur[0].SetActive(true);
            }
        }
        else if(photoStage == 4)
        {
            paper[1].SetActive(true);
            photo[1].GetComponent<Image>().sprite = photoSprite;
        }
        else
        {
            photo[2].GetComponent<Image>().sprite = photoSprite;
        }
        if (photoStage == 6)
        {
            this.GetComponent<Animator>().SetTrigger("Bar");
        }
        ps.photoStage = photoStage;

    }

}
