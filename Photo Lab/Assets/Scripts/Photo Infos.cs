using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoInfos : MonoBehaviour
{
    public bool photoVertical;
    [Header("Stage")]
    public int actualStage;
    [SerializeField]
    private PlayerScript ps;
    /*Stages
    0	Ajustar o foco
    1	Luz vermelha
    2	Bandeja (revelador)
    3	Bandeja (Interruptor)
    4	Bandeja (Fixador)
    5	Varal
    6	Retoque
    7	Devolução
    */

    private void Awake()
    {
        photoVertical = ps.photoVertical;
    }
    private void OnEnable()
    {
        //ps = GameObject.Find("Player").GetComponent<PlayerScript>();

        actualStage = ps.photoStage;
        this.GetComponent<SpriteRenderer>().sprite = ps.photoSprite;
        photoVertical = ps.photoVertical;
    }

    private void OnDisable()
    {
        ps.photoStage = actualStage;
    }
    private void Update()
    {
    }
    public void NextStage()
    {
        actualStage++;
    }

}
