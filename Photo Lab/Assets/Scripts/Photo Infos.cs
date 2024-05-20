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
        needRet = ps.photoNeedRet;
        photoRetCounts = ps.photoRetCount;
        try { this.GetComponent<SpriteRenderer>().sprite = ps.photoSprite; }
        catch { }
        photoVertical = ps.photoVertical;
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
