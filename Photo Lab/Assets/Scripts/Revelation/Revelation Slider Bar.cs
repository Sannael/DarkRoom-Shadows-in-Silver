using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RevelationSliderBar : MonoBehaviour
{
    public bool trayRevelation;
    public GameObject pointer;
    public float pointerTime;
    public float pointerSpeed;

    private Vector3 pointerPos;
    private bool toUp;
    private string colName;
    public bool sliding;

    private int score;

    void Start()
    {
        score = 0;
        toUp = true;
        pointerPos = pointer.GetComponent<RectTransform>().anchoredPosition;
    }
    private void OnEnable()
    {
        sliding = true;
    }

    void Update()
    {
        colName = pointer.GetComponent<Pointer>().colName;
        StartCoroutine(MovePointer());

        if (sliding)
        {
            if (Input.GetMouseButton(0))
            {
                PointerClick(colName);
            }
        }
        if(score >= 10)
        {
            this.gameObject.SetActive(false);
            if(this.GetComponentInParent<RevelationScript>().photoStage == 4)
            {
                this.GetComponentInParent<RevelationScript>().LastStageSettings();
               
            }
            if(this.GetComponentInParent<RevelationScript>().photoStage != 6)
            {
                this.GetComponentInParent<RevelationScript>().photoStage ++;
                this.gameObject.SetActive(false);
            }
        }
        
    }

    public void PointerClick(string p)
    {
        if(trayRevelation)
        {
            if(p == "Green")
            {
                this.GetComponentInParent<RevelationScript>().ChangeOpacPhoto(40);
            }
            else if (p == "Yellow")
            {
                this.GetComponentInParent<RevelationScript>().ChangeOpacPhoto(150); //18);
            }
            else
            {
                this.GetComponentInParent<RevelationScript>().ChangeOpacPhoto(-15);
            }
        }
        else
        {
            if (p == "Green")
            {
                score += 2;
            }
            else if (p == "Yellow")
            {
                score += 10;  //++;
            }
            else
            {
                score--;
            }
        }
        
        sliding = false;
        toUp = !toUp;
        StartCoroutine(PointerAfterClick());
    }

    public IEnumerator PointerAfterClick()
    {
        pointer.GetComponent<Image>().color = new Color32(0, 0, 0, 200);
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        sliding = true;
    }

    public IEnumerator MovePointer()
    {
        if (toUp)
        {
            if (pointerPos.y < 350)
            {
                pointerPos.y += pointerSpeed;
                pointer.GetComponent<RectTransform>().anchoredPosition = pointerPos;
                yield return new WaitForSeconds(pointerTime);
            }
            else
            {
                toUp = false;
            }
        }
        else
        {
            if (pointerPos.y > -350)
            {
                pointerPos.y -= pointerSpeed;
                pointer.GetComponent<RectTransform>().anchoredPosition = pointerPos;
                yield return new WaitForSeconds(pointerTime);
            }
            else
            {
                toUp = true;
            }
        }
    }
}
