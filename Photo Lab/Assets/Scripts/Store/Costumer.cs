using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Costumer : MonoBehaviour
{
    [System.Serializable]
    public class Speakers
    {
        public Sprite speakerPortrait;
        public string speakerName;
        [Header("Whole Sprites")]
        public Sprite[] fullBodySprites; //A ideia aqui � armazenar os sprites dos candangos em p� (inativo e ativo (Respectivamente) por hora) 
    }
    public Speakers[] speaker;
    public int costumerID;
    [Header("Dialogues")]
    public int totalDialogueLines; //#G: Informa��o relevante para gerar as keys da tabela de localiza��o (substitui a antiga lista de di�logos embutida no costumer)
    public int middleDialogue; //#G: Marca��o intermedi�ria dos di�logos para os clientes que tem mais de 3 a��es
    public int lastDialogue;//
    public int thirdSpeakerStartDialogue; //#G: Marca��o para definir o momento em que o terceiro interlocutor aparace na cena

    [Header("Photo Area")]
    public Sprite photoSprite;
    public bool hotoVertical;
    public int photoStage;
    [Header("Retoque Part")]
    [Tooltip("Marcar apensar se a foto precisar de retoque")]
    public bool needRet;
    public int photoRetCount;
    public Sprite truePhotoRet;
    public Sprite photoRet;
    public GameObject photoRetObj; //Prefab da foto com os erros para o retoque
    public GameObject photoRetLocations; //Prefab com os erros das imagens
    public Sprite photoRetSprite;

    [Header("Special Cases!")]
    public bool fakePhotoNeedRet;
    public Sprite fakePhotoRet;
    public GameObject fakePhotoRetObj;

    [Header("Event Triggers")]
    public EventTrigger[] evt;

    [Header("Final Characters")]
    public bool finalChar;

    public int costumerAction = 0; //#G 0 = entregar o negativo; 1 = esperar a foto; 2 = receber a foto; 3 = esperar a foto; 4 = receber a foto; 
    public int lastCostumerAction; //#G Definir o n�mero de total a��es, para os casos em que h� mais de 3 a��es


    private void Awake()
    {
        int e = 0;
        evt = new EventTrigger[transform.childCount];
        foreach(Transform t in transform)
        {
            t.gameObject.tag = this.tag;
            evt[e] = t.gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((functionIWant) => { CostumerClick(); });
            evt[e].triggers.Add(entry);
            e++;
        }
    }

    public void CostumerClick()
    {
        if (needRet)
        {
            photoRetCount = photoRetObj.transform.childCount;
        }
        this.GetComponentInParent<Store>().NextDialogue();
    }
    public void Update()
    {
        photoStage = GameObject.Find("Player").GetComponent<PlayerScript>().photoStage;
    }

    public Sprite ReturnSpeakerSprite(string sName)
    {
        Sprite r = null;
        for(int i =0; i <speaker.Length; i ++)
        {
            if(speaker[i].speakerName == sName)
            {
                r = speaker[i].speakerPortrait;
            }
        }
        return r;
    }

    public Sprite ReturnSpeakerBodySprite(string sName, bool speaking)
    {
        Sprite r = null;
        for(int i =0; i < speaker.Length; i++)
        {
            if(speaker[i].speakerName == sName)
            {
                if (speaking)
                {
                    r = speaker[i].fullBodySprites[1];
                }
                else
                {
                    r = speaker[i].fullBodySprites[0];
                }
            }
        }
        return r;
    }
}
