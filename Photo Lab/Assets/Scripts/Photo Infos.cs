using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoInfos : MonoBehaviour
{
    public bool photoVertical;
    public bool needRet;
    public int photoRetCounts; //quantidade de botoes de retoque (Gambiarra)
    public Sprite truePhotoRet;
    public Sprite photoRet;
    [Header("Stage")]
    public int actualStage;
    [SerializeField]
    private PlayerScript ps;

    /*Stages
    -1  Jornal
    0	Loja
    1   Ajustar o foco
    2	Luz vermelha
    3	Bandeja (revelador)
    4	Bandeja (Interruptor)
    5	Bandeja (Fixador)
    6	Varal
    7	Retoque
    8	Devolução
    */

    private void Awake()
    {
        photoVertical = ps.photoVertical;
    }
    private void OnEnable()
    {
        //ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        actualStage = ps.photoStage;
        needRet = ps.photoNeedRet;
        photoRetCounts = ps.photoRetCount;
        try { this.GetComponent<SpriteRenderer>().sprite = ps.photoRetSprite; }
        catch { }
        photoVertical = ps.photoVertical;

        if(actualStage == 1 || actualStage > 5) 
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void OnDisable()
    {
        
    }
    private void Update()
    {
    }
    public void NextStage()
    {
        actualStage++;
        if(actualStage == 3)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 50);
            ps.photoColor = this.GetComponent<SpriteRenderer>().color;
        }
        ps.photoStage = actualStage;
    }

}
