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
        public Sprite[] fullBodySprites; //A ideia aqui é armazenar os sprites dos candangos em pé (inativo e ativo (Respectivamente) por hora) 
    }
    public Speakers[] speaker;
    public int costumerID;
    [Header("Dialogues")]
    [TextArea(5,7)]
    public string[] texts;
    public int lastDialogues;

    [Header("Photo Area")]
    public Sprite photoSprite;
    public bool hotoVertical;
    public int photoStage;

    [Header("Event Triggers")]
    public EventTrigger[] evt;

    public int costumerAction =0; //0 = entregar o negativo; 1 = esperar a foto; 2 = receber a foto

    

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
