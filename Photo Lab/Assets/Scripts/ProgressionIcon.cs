using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionIcon : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject[] checks;
    public GameObject newsPaperIcon;

    private PlayerScript ps;
    [SerializeField]
    private int iconsStage; //-1 jornal; 0 = loja; 1 = ampliador; 2= Revelador; 3= Retoque; 4= Entrega

    private void Awake()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        iconsStage = ps.photoStage;
        int i = 0;
        foreach(GameObject g in icons) 
        {
            checks[i] = g.transform.GetChild(0).gameObject;
            g.SetActive(false);
            checks[i].SetActive(false);
            i++;
        }
    }

    public void Update()
    {
        if (ps.photoStage == -1 && iconsStage >3)
        {
            iconsStage = -2;
            ChangeIcons(-1);
        }
        else if (ps.photoStage == 0 && iconsStage == -1) 
        {
            ChangeIcons(0);
        }
        else if (ps.photoStage == 1 && iconsStage == 0)
        {
            ChangeIcons(1);
        }
        else if(ps.photoStage == 3 && iconsStage == 1) 
        {
            ChangeIcons(2);
        }
        else if(ps.photoStage == 6 && iconsStage == 2) 
        {
            ChangeIcons(3);
        }
        else if (ps.photoStage == 8 && iconsStage == 3) 
        {
            ChangeIcons(4);
        }
    }

    public void ChangeIcons(int state) 
    {

        if (state == -1)
        {
            foreach (GameObject g in checks)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in icons)
            {
                g.SetActive(false);
                g.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            newsPaperIcon.SetActive(true);
        }
        else if (state == 0)
        {
            newsPaperIcon.SetActive(false);
            icons[0].SetActive(true);
        }
        else
        {
            icons[state - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            checks[state - 1].SetActive(true);
            icons[state].SetActive(true);
        }

        iconsStage++;
        /*switch (state) 
        {
            case 0:
                foreach (GameObject g in checks)
                {
                    g.SetActive(false);
                }
                foreach (GameObject g in icons) 
                {
                    g.SetActive(false);
                }
                break;

            case 1:
                icons[0].SetActive(true);
                break;

            case 2:
                checks[0].SetActive(true);
                icons[1].SetActive(true);
                break;
        }*/
    }
}
