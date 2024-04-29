using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanelClose : MonoBehaviour
{
    public int firstStage;
    public int lastStage;// Ultimo estado que o painel pode realizar (Seguir numeros do  photo infos script)
    public Button btnClose;
    private GameObject panel;
    private bool speaking;
    private Store storeScript;
    


    private void Start()
    {
        panel = this.gameObject;
        try { storeScript = panel.GetComponent<Store>(); }
        catch { speaking = false; }


    }
    void Update()
    {
        if(storeScript != null)
        {
            speaking = storeScript.speaking;
        }
        PlayerScript ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        if (speaking)
        {
            btnClose.interactable = false;
        }
        else
        {
            if(ps.photoSprite == null)
            {
                btnClose.interactable = true;
            }
            else if (ps.photoStage > lastStage || ps.photoStage < firstStage)
            {
                btnClose.interactable = true;
            }
            else
            {
                btnClose.interactable = false;
            }
        }
        
    }

    public void ClosePanel()
    {
        if (storeScript != null)
        {
            if (storeScript.dialogueIsOver == true)
            {
                storeScript.actualCostumerID++;
              
                NewsPaper newsPaperScript = GameObject.Find("Canvas").transform.GetChild(4).gameObject.GetComponent<NewsPaper>(); //#G: Gambiarra 
                
                if (newsPaperScript != null) 
                {
                    switch (storeScript.actualCostumerID) //# Atualiza o ID do jornal conforme o ID do cliente atual
                    {
                        case 0:
                            newsPaperScript.actualNewsPaperID = 0;
                            break;
                        case 1 or 2:
                            newsPaperScript.actualNewsPaperID = 1;
                            break;
                        case 3 or 4:
                            newsPaperScript.actualNewsPaperID = 2;
                            break;
                        case 5:
                            newsPaperScript.actualNewsPaperID = 3;
                            break;
                        case 6:
                            newsPaperScript.actualNewsPaperID = 4;
                            break;
                        case 7:
                            newsPaperScript.actualNewsPaperID = 5;
                            break;
                        case 8:
                            newsPaperScript.actualNewsPaperID = 7;
                            break;
                        case 9:
                            newsPaperScript.actualNewsPaperID = 8;
                            break;
                        case 10:
                            newsPaperScript.actualNewsPaperID = 9;
                            break;
                        case 11:
                            newsPaperScript.actualNewsPaperID = 10;
                            break;
                        default:
                            newsPaperScript.actualNewsPaperID = 0;
                            break;
                    }
                }
                
                storeScript.dialogueIsOver = false;
            }
            
        }
        GameObject.Find("Game Controller").GetComponent<GameControllerScript>().seeQuestPointer = true;
        panel.SetActive(false);
        GameObject.Find("Camera Follow").GetComponent<CameraFollow>().backToPos = true;
        GameObject.Find("Player").GetComponent<PlayerScript>().canMove = true;
    }
}
