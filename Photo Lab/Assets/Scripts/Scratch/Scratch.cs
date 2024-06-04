using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scratch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera scratchCamera;
    public GameObject[] lines;
    [Header("Photo Area")]
    //public GameObject photo;
    public Sprite photoSprite;
    public bool vertical;
    public int photoStage;
    public bool photoNeedRet;
    public int photoRetCounts; //Contagem de retoques (botoes ocultos / gambiarra)
    public Sprite truePhotoRet;
    public Sprite photoRet;

    [Header("Objects")]
    public GameObject brush;
    public GameObject photoObj; //local onde a foto vai
    public GameObject photoRetObj; //local onde o sprite de retoque vai
    public GameObject photoRetLocations; //prefab que vem do cliente com a parte dos erros nas fotos q precisam de retoque 
    
    [SerializeField]
    private PhotoInfos photoInfo;
    private PlayerScript ps;
    private GameObject retL;

    private void OnEnable()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        scratchCamera.gameObject.SetActive(true); //ativa a camera q possibilita apagar os objetos
        photoSprite = ps.photoSprite;
        vertical = ps.photoVertical;
        photoStage = ps.photoStage;
        photoNeedRet = ps.photoNeedRet;
        photoRetCounts = ps.photoRetCount;
        photoRetLocations = ps.photoRetLocations;

        photoObj.GetComponent<Image>().sprite = ps.truePhotoRet;

        photoRetObj.SetActive(false);
        if (ps.photoStage == 7) 
        {
            if (photoNeedRet)
            {
                brush.GetComponent<BrushScript>().interactive = true;
                brush.GetComponent<BrushScript>().scratchScript = GetComponent<Scratch>();
            }
        }    //mainCamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("Scratching"); //Torna visivel a parte dos "Rabiscos" da mecania de retoque
    }

    public void EnableRet() 
    {
        retL = GameObject.Instantiate(photoRetLocations, photoObj.transform);
        retL.GetComponent<Image>().sprite = null;
        photoRetObj.GetComponent<Image>().sprite = ps.photoRet;
        photoRetObj.GetComponent<Image>().SetNativeSize();
        photoRetObj.SetActive(true);
        photoRetObj.GetComponent<Image>().material.SetTexture("_Pattern", ps.photoRet.texture); //altera a textura para os erros da imagem e torna visivel

        GameObject.Instantiate(ps.photoRetObj);
    }
    private void OnDisable()
    {
        lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject l in lines) 
        {
            Destroy(l);
            Destroy(retL);
        }
        lines = null;
        scratchCamera.gameObject.SetActive(false);
        //mainCamera.GetComponent<Camera>().cullingMask &=  ~(1 << LayerMask.NameToLayer("Scratching")); //Torna invisivel a parte dos "Rabiscos" da mecania de retoque
    }

    // Update is called once per frame
    void Update()
    {
        if (photoNeedRet)
        {
            if (photoRetCounts <= 0)
            {
                ps.photoStage++;
                photoNeedRet = false;
                ps.photoNeedRet = false;
                photoStage++;
                brush.GetComponent<Image>().enabled = true;
                CursorScript.cursorInstace.ChangeCursor("Idle");
            }
        }
        else if(photoStage == 7) 
        {
            ps.photoStage ++;
        }
        
    }

}
