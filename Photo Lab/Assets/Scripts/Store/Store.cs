using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings; //#G: Adicionei para poder chamar os metodos da localização
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Store : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject portrait;
    public TMP_Text speakerName, speakerTextbox;
    public Costumer costumerScript;
    public Costumer prefabCostumerScript;
    [SerializeField]
    private int actualDialogue;
    [SerializeField]
    private EventTrigger[] evt;
    private PlayerScript ps;

    [Header("Customers Area")]
    public GameObject[] allCostumers;
    public int actualCostumerID;
    [SerializeField]
    private GameObject costumer;
    private int costumerFirstDialogue;
    private int costumerLastDialogue;
    private int costumertotalDialogLines; //#G: Recebe o total de linhas de diálogo para gerar as keys da tabela de localização
    public bool speaking = false;
    [HideInInspector]
    public bool dialogueIsOver = false; //#G: Para checar se a conversa com o cliente chegou ao fim, para passar para o próximo cliente

    public GameObject photoRetLocations; //prefab com os erros das fotos que precisam de retoque
    public GameObject choosePnl; //Painel com a escolha final
    private int finalId = 99; //valor random só pra n dar pau

    public GameObject gameController;

    [Header("SFX")]
    public GameObject dialogueSoundObj;
    private void OnEnable()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        ps.canMove = false;
        speaking = false;
        dialogueIsOver = false;
        if (ps.photoStage != -1)
        {
            foreach (GameObject c in allCostumers)
            {
                if (c.GetComponent<Costumer>().costumerID == actualCostumerID)
                {
                    prefabCostumerScript = c.GetComponent<Costumer>();
                    
                    //if()
                    if (prefabCostumerScript.costumerAction == 0 || prefabCostumerScript.costumerAction == 2 || prefabCostumerScript.costumerAction == 4)
                    {

                        costumer = Instantiate(c);
                        costumer.transform.SetParent(this.transform);
                        costumer.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                        costumerScript = costumer.GetComponent<Costumer>();
                        evt = costumer.GetComponent<Costumer>().evt;
                        costumertotalDialogLines = costumerScript.totalDialogueLines; //#G: Puxa o total de linhas de diálogo para gerar as keys da tabela de localização

                        if (costumerScript.costumerAction < 2 & costumerScript.lastCostumerAction == 2) //#G: Checa se a ação atual é menor que 2 e o tatal de ações é dois
                        {
                            costumerLastDialogue = costumerScript.lastDialogue;
                            costumerFirstDialogue = 0;
                        }
                        else if (costumerScript.costumerAction < 2 & costumerScript.lastCostumerAction > 2) //#G: Checa se a ação atual é menor que 2 e o tatal de ações é maior que dois
                        {
                            costumerLastDialogue = costumerScript.middleDialogue;
                            costumerFirstDialogue = 0;
                        }
                        else if (costumerScript.costumerAction < costumerScript.lastCostumerAction & costumerScript.lastCostumerAction > 2) //#G: Checa se a ação atual é menor que o tatal de ações e se o total de açõesé maior que dois
                        {
                            costumerFirstDialogue = costumerScript.middleDialogue;
                            costumerLastDialogue = costumerScript.lastDialogue;
                        }
                        else if (costumerScript.lastCostumerAction == 2) //#G: Nos casos em que há 3 ações:
                        {
                            costumerFirstDialogue = costumerScript.lastDialogue;
                            costumerLastDialogue = costumertotalDialogLines;
                        }
                        else //#G: Nos casos em que há mais que 3 ações:
                        {
                            costumerFirstDialogue = costumerScript.lastDialogue;
                            costumerLastDialogue = costumertotalDialogLines;
                        }

                        if (costumerScript.speaker.Length > 2) //#G: Checagem para ativar o sprite do terceiro interlocutor logo ao carregar a loja
                        {
                            if (costumerFirstDialogue >= costumerScript.thirdSpeakerStartDialogue)
                            {
                                GameObject.Find(costumerScript.speaker[2].speakerName).gameObject.GetComponent<Image>().enabled = true;
                            }
                        }

                    }
                }
            }
        }
        dialogueBox.SetActive(false);
    }


    private void OnDisable()
    {
        Destroy(costumer);
        dialogueSoundObj.SetActive(false);
        ps.canMove = true;
        this.GetComponent<ClosePnls>().PlaySound();
    }

    private void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        actualDialogue = 0;
    }
    private void Update()
    {
        if (dialogueBox.transform.GetSiblingIndex() != 4)
        {
            dialogueBox.transform.SetSiblingIndex(4);
        }
        if (evt[0] != null)
        {
            if (actualDialogue == 0)
            {
                foreach (EventTrigger e in evt)
                {
                    e.enabled = true;
                }
            }
            else
            {
                foreach (EventTrigger e in evt)
                {
                    e.enabled = false;
                }
            }
        }

        if(prefabCostumerScript.finalChar && dialogueIsOver) 
        {
            ManagerScene.sceneManagerInstance.LoadScene(2);
            //gameController.GetComponent<GameControllerScript>().LoadFinal(2);
        }
    }

    [ContextMenu("NextDialogue")]
    public void NextDialogue()
    {
        StopAllCoroutines();
        dialogueSoundObj.SetActive(false);
        GameObject[] chars = GameObject.FindGameObjectsWithTag("Store Char");
        string[] charactersName = new string[chars.Length];
        for (int i = 0; i < chars.Length; i++)
        {
            charactersName[i] = chars[i].name;
        }
        speakerTextbox.text = "";
        if (actualDialogue < costumerFirstDialogue)
        {
            actualDialogue = costumerFirstDialogue + 1;
        }

        if (actualDialogue < costumertotalDialogLines && actualDialogue <= costumerLastDialogue)
        {
            string ActualLocKey = "Costumer" + actualCostumerID.ToString() + "_" + actualDialogue.ToString(); //#G: Gera a key para puxar o texto da tabela de localização baseada no id do cliente e no diálogo atual
            //Debug.Log(ActualLocKey);
            speaking = true;
            dialogueBox.SetActive(true);
            dialogueIsOver = false;
            string[] alltext = LocalizationSettings.StringDatabase.GetLocalizedString("DialogTable", ActualLocKey).Split("{} "); //#G: Puxa o texto da tabela de localização
            string sName = alltext[0];
            string sText = alltext[1];
            Sprite sSprite = costumerScript.ReturnSpeakerSprite(sName);
            ShowDialogue(sSprite, sName, sText);
            actualDialogue++;

            for (int i = 0; i < charactersName.Length; i++)
            {
                if (sName == charactersName[i])
                {   
                    ChangeFullBodySprites(chars[i], charactersName[i], true);
                }
                else
                {
                    ChangeFullBodySprites(chars[i], charactersName[i], false);
                    //chars[i].GetComponent<Image>().sprite = costumerScript.ReturnSpeakerBodySprite(charactersName[i], false);
                }
            }
            if (prefabCostumerScript.costumerID == 6)
            {
                choosePnl.SetActive(true);
            }
        }
        else
        {
            
            if (costumerLastDialogue == costumertotalDialogLines) //#G: Para permitir trocar o id do cliente caso tenha chegado ao fim dos diálogos
            {
                dialogueIsOver = true;
            }
            else
            {
                dialogueIsOver = false;
            }

            //Debug.Log("else");
            if (costumerScript.costumerAction == 2)
            {
                //Debug.Log("costumerAction 2");
                //ManagerScene.sceneManagerInstance.LoadScene(2);
            }
            speaking = false;
            EnableDisableDialogueBox(false);
            actualDialogue = 0;
            if (actualCostumerID != 6)
            {
                GiveTakePhoto();
            }
        }
    }

    public void GiveTakePhoto()
    {
        if (prefabCostumerScript.costumerAction == 0)
        {
            ps.photoColor = new Color32(255, 255, 255, 255);
            ps.photoSprite = costumerScript.photoSprite;
            ps.photoVertical = costumerScript.hotoVertical;
            ps.photoStage = 1;
            ps.photoNeedRet = costumerScript.needRet;
            ps.photoRetCount = costumerScript.photoRetCount;
            ps.photoRet = costumerScript.photoRet;
            ps.truePhotoRet = costumerScript.truePhotoRet;
            ps.photoRetObj = costumerScript.photoRetObj;
            prefabCostumerScript.costumerAction = 1;
            ps.photoRetLocations = costumerScript.photoRetLocations;
            if (costumerScript.photoRetSprite != null)
            {
                ps.photoRetSprite = costumerScript.photoRetSprite;
            }
            else 
            {
                ps.photoRetSprite = costumerScript.photoSprite;
            }
            if (prefabCostumerScript.costumerID == 2) //Tratar um cliente em especifico
            {
                ps.truePhotoRet = costumerScript.fakePhotoRet;
                ps.photoRetObj = costumerScript.fakePhotoRetObj;
                ps.photoRetLocations = costumerScript.fakePhotoRetObj;
                ps.photoNeedRet = costumerScript.fakePhotoNeedRet;
            }
            else if(prefabCostumerScript.costumerID == 5) 
            {
                ps.truePhotoRet = costumerScript.fakePhotoRet;
                ps.photoRetObj = costumerScript.fakePhotoRetObj;
                ps.photoRetLocations = costumerScript.fakePhotoRetObj;
                ps.photoNeedRet = costumerScript.fakePhotoNeedRet;
            }
        }
        else if (prefabCostumerScript.costumerAction == 2 & prefabCostumerScript.lastCostumerAction == 2) //#G: Caso sejam apenas 3 ações
        {
            ps.photoSprite = null;
            ps.photoStage = -1; //mudei pra -1 por causa do jornal
            prefabCostumerScript.costumerAction = 3;
            dialogueIsOver = true;
            actualDialogue = 0;
        }
        else if (prefabCostumerScript.costumerAction == 2 & prefabCostumerScript.lastCostumerAction > 2) //#G: Caso sejam mais de 3 ações
        {
            /*ps.photoColor = new Color32(255, 255, 255, 255);
            ps.photoSprite = costumerScript.photoSprite;
            ps.photoVertical = costumerScript.hotoVertical;
            ps.photoStage = 1;
            prefabCostumerScript.costumerAction = 3;*/
            ps.photoColor = new Color32(255, 255, 255, 255);
            ps.photoSprite = costumerScript.photoSprite;
            ps.photoVertical = costumerScript.hotoVertical;
            ps.photoStage = 1; //reinicia o processo
            ps.photoNeedRet = costumerScript.needRet;
            ps.photoRetCount = costumerScript.photoRetCount;
            ps.photoRet = costumerScript.photoRet;
            ps.truePhotoRet = costumerScript.truePhotoRet;
            ps.photoRetObj = costumerScript.photoRetObj;
            prefabCostumerScript.costumerAction = 3;
            ps.photoRetLocations = costumerScript.photoRetLocations;

            if(actualCostumerID == 2) 
            {
                ps.photoStage = 6; //caso for Mauro + Guedes // Manipular foto
            }
        }
        else if (prefabCostumerScript.costumerAction == 4) //#G: Caso sejam mais de 3 ações
        {
            ps.photoSprite = null;
            ps.photoStage = -1; //mudei pra -1 por causa do jornal
            prefabCostumerScript.costumerAction = 5;
            dialogueIsOver = true;
            actualDialogue = 0; 
        }

    }

    public void ChangeFullBodySprites(GameObject charChange, string charName, bool active)
    {
        charChange.GetComponent<Image>().sprite = costumerScript.ReturnSpeakerBodySprite(charName, active);
    }

    public void ShowDialogue(Sprite sSprite, string sName, string sText)
    {
        if (costumerScript.speaker.Length > 2) //#G: Checagem para ativar o sprite do terceiro interlocutor quando ele deveria aparecer na cena
        {
            if (sName == costumerScript.speaker[2].speakerName) 
            {
                GameObject.Find(costumerScript.speaker[2].speakerName).gameObject.GetComponent<Image>().enabled = true;
            }
        }
        
        portrait.GetComponent<Image>().sprite = sSprite;
        speakerName.text = sName;
        StartCoroutine(DialogueTime(sText));
    }

    public IEnumerator DialogueTime(string sText)
    {
        dialogueSoundObj.SetActive(true);
        for (int i = 0; i < sText.Length; i++)
        { 
            speakerTextbox.text += sText[i];
            yield return new WaitForSeconds(0.03f);
        }
        dialogueSoundObj.SetActive(false);
    }

    public void EnableDisableDialogueBox(bool active)
    {
        dialogueBox.SetActive(active);
        actualDialogue = 0;
        if (active)
        {
            NextDialogue();
        }
        else
        {
            GameObject[] chars = GameObject.FindGameObjectsWithTag("Store Char");
            foreach (GameObject obj in chars)
            {
                ChangeFullBodySprites(obj, obj.name, false);
            }
        }
    }

    public void SkipDialogues()
    {
        actualDialogue = 999;
        NextDialogue();
    }


    public void ChooseFinal(int final) 
    {
        choosePnl.SetActive(false);
        Destroy(costumer);
        ps.photoStage = -1;
        EnableDisableDialogueBox(false);
        speaking = false;
        switch (final) 
        {
            case 0:
                actualCostumerID = 7;
                break;
            case 1:
                actualCostumerID = 9;
                break;
        }
        finalId = final;
    }
}
