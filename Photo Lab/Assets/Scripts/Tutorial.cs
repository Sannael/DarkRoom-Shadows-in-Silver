using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Sprite[] imagensTutorial;
    public int tutorialID;
    [SerializeField] private GameObject BotaoVoltar, BotaoAvancar, BotaoMenu;


    // Start is called before the first frame update
    void Start()
    {
        tutorialID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialID) //# Atualiza o ID do jornal conforme o ID do cliente atual
        {
            case 0:
                this.GetComponent<Image>().sprite = imagensTutorial[0];
                break;
            case 1:
                this.GetComponent<Image>().sprite = imagensTutorial[1];
                break;
            case 2:
                this.GetComponent<Image>().sprite = imagensTutorial[2];
                break;
            case 3:
                this.GetComponent<Image>().sprite = imagensTutorial[3];
                break;
            case 4:
                this.GetComponent<Image>().sprite = imagensTutorial[4];
                break;
            case 5:
                this.GetComponent<Image>().sprite = imagensTutorial[5];
                break;
            case 6:
                this.GetComponent<Image>().sprite = imagensTutorial[6];
                break;
            case 7:
                this.GetComponent<Image>().sprite = imagensTutorial[7];
                break;
            case 8:
                this.GetComponent<Image>().sprite = imagensTutorial[8];
                break;
            case 9:
                this.GetComponent<Image>().sprite = imagensTutorial[9];
                break;
            case 10:
                this.GetComponent<Image>().sprite = imagensTutorial[10];
                break;
            case 11:
                this.GetComponent<Image>().sprite = imagensTutorial[11];
                break;
            case 12:
                this.GetComponent<Image>().sprite = imagensTutorial[12];
                break;
            case 13:
                this.GetComponent<Image>().sprite = imagensTutorial[13];
                break;
            case 14:
                this.GetComponent<Image>().sprite = imagensTutorial[14];
                break;
            case 15:
                this.GetComponent<Image>().sprite = imagensTutorial[15];
                break;
            case 16:
                this.GetComponent<Image>().sprite = imagensTutorial[16];
                break;
            case 17:
                this.GetComponent<Image>().sprite = imagensTutorial[17];
                break;
            case 18:
                this.GetComponent<Image>().sprite = imagensTutorial[18];
                BotaoMenu.SetActive(false);
                BotaoAvancar.SetActive(true);
                break;
            case 19:
                this.GetComponent<Image>().sprite = imagensTutorial[19];
                BotaoAvancar.SetActive(false);
                BotaoMenu.SetActive(true);
                break;
            default:
                this.GetComponent<Image>().sprite = imagensTutorial[0];
                break;
        }
    }

    public void AvancarTutorialID()
    {
        tutorialID += 1;
    }

    public void VoltarTutorialID()
    {
        if (tutorialID > 0)
        {
            tutorialID -= 1;
        }
        else
        {
            ManagerScene scenem = ManagerScene.sceneManagerInstance;
            scenem.LoadScene(0);
        }
        
    }
}
