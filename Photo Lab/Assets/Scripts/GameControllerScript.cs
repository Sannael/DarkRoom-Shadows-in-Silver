using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Store storeScript;
    public PlayerScript ps;
    public int photoFinal;


    private GameObject[] workSpaces;
    private ButtonsPanelClose[] workSpaceBtn;
    public GameObject workSpaceStore;
    public GameObject questPointer;
    public bool seeQuestPointer;

    public GameObject[] costumers;

    private void Awake()
    {
        foreach (GameObject c in costumers) 
        {
            c.GetComponent<Costumer>().costumerAction = 0;
        }
    }
    private void Start()
    {
        seeQuestPointer = true;
        TakeWorkspaces();
    }
    private void Update()
    {
        
        if (seeQuestPointer)
        {
            questPointer.SetActive(true);
        }
        else
        {
            questPointer.SetActive(false);
        }
        if(ps.photoStage == photoFinal && storeScript.prefabCostumerScript.costumerAction ==1)
        {
            storeScript.prefabCostumerScript.costumerAction = 2;
        }
        if (ps.photoStage == photoFinal && storeScript.prefabCostumerScript.costumerAction == 3) //#G: Quando o cliente tiver mais de 2 ações
        {
            storeScript.prefabCostumerScript.costumerAction = 4;
        }

        if (ps.photoStage < photoFinal)
        {
            NextToUse();
        }
        else
        {
            questPointer.GetComponent<Window_QuestPointer>().ChangeTarget(workSpaceStore.transform.position);
        }
    }

    private void TakeWorkspaces()
    {
        workSpaces = GameObject.FindGameObjectsWithTag("Work Space");
        workSpaceBtn = new ButtonsPanelClose[workSpaces.Length];
        int id = 0;
        foreach (GameObject obj in workSpaces)
        {
            if(obj.name == "Balcao")
            {
                workSpaceStore = obj;
            }
            workSpaceBtn[id] = workSpaces[id].GetComponent<CheckDistance>().workPanel.gameObject.GetComponent<ButtonsPanelClose>();
            id++;
        }
    }
    
    private void NextToUse()
    {
        int i = 0;
        foreach(ButtonsPanelClose btn in workSpaceBtn)
        {
            if(ps.photoStage >= btn.firstStage && ps.photoStage <= btn.lastStage)
            {
                questPointer.GetComponent<Window_QuestPointer>().ChangeTarget(workSpaces[i].transform.position);
            }
            
            i++;
        }
    }

    public void LoadFinal(int final) 
    {
        switch (final) 
        {
            case 0:
                break;
                //logica utilizando o jornal para puxar as informações do final escolhido...
            case 1:
                //logica utilizando o jornal para puxar as informações do final escolhido...
                break;
        }
    }
}


