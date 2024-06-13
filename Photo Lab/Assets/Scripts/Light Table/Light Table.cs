using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTable : MonoBehaviour
{
    [Header("Red Light Part")]
    public float redLightTime;
    public GameObject redLight;
    public Button redLightButton;
    private bool canRedLight;
    private bool alreadyUseLight = false;
    [Header("Focus Part")]
    public GameObject fakeFocus; //foco que mexe de vdd, o foco original n rotaciona, ele só copia esse (lembrar de habilitar e desabilitar qnd necessario)
    [Header("Paper Area")]
    public GameObject verticalPaper;
    public GameObject horizontalPaper;
    public GameObject photo;
    public GameObject photoBG;
    public bool photoVertical;
    [Header("Blur Area")]
    public GameObject blurUI;

    public GameObject lightTableItens;

    private PhotoInfos photoInfo;
    private PlayerScript ps;

    [Header("SFX")]
    public AudioClip redLightSound;
    public AudioClip redLightTimerSound;
    private GameObject timerSFX;
    void Start()
    {
        canRedLight = false;
        
    }
    private void OnEnable()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        ps.canMove = false;
        alreadyUseLight = false;
        canRedLight = false;
        photoInfo = photo.GetComponent<PhotoInfos>();
        lightTableItens.SetActive(true);
        photoVertical = photo.GetComponent<PhotoInfos>().photoVertical;
        CheckPhoto(); //tenho que puxar isso da foto
        if (photoInfo.actualStage == 1)
        {
            blurUI.SetActive(true);
        }
        else
        {
            blurUI.SetActive(false);
        }
    }
    private void OnDisable()
    {
        ps.canMove = true;
        lightTableItens.SetActive(false);
        this.GetComponent<ClosePnls>().PlaySound();
    }

    void Update()
    {
        if (!canRedLight)
        {
            redLightButton.interactable = false;
        }
        else if(!alreadyUseLight)
        {
            redLightButton.interactable = true;
        }
        if (photoInfo.actualStage == 1 && photo.GetComponent<SpriteRenderer>().sprite != null)
        {
            fakeFocus.GetComponent<FocusRotate>().enabled = true;

            NovaSamples.Effects.BlurEffect blurEffectScript = blurUI.GetComponent<NovaSamples.Effects.BlurEffect>();
            if(blurEffectScript.BlurRadius <= 2) //Margem de erro do Blur
            {
                canRedLight = true; //ajeitar essa merda pra poder fazer sentido para o player
            }
            else
            {
                canRedLight = false;
            }
        }
        else
        {
            fakeFocus.GetComponent<FocusRotate>().enabled = false;
        }


        
    }

    public void RedLightButton()
    {
        if (!alreadyUseLight) 
        {
            photoInfo.NextStage();
            alreadyUseLight = true;
            canRedLight = false;
            StartCoroutine(RedLight());
            Sounds.instance.PlaySingle(redLightSound);
            timerSFX = Sounds.instance.CreateNewSoundLoop(redLightTimerSound);
        }
        
    }


    public IEnumerator RedLight()
    {
        redLight.SetActive(true);
        blurUI.SetActive(false);
        yield return new WaitForSeconds(redLightTime);
        Destroy(timerSFX);
        Sounds.instance.PlaySingle(redLightSound);
        redLight.SetActive(false);
        photoInfo.NextStage();
    }

    public void CheckPhoto()
    {
        Vector2 photoSize = new Vector2();
        if(photo.GetComponent<SpriteRenderer>().sprite != null)
        {
            Sprite photoSprite = photo.GetComponent<SpriteRenderer>().sprite;

            photoSize[0] = photoSprite.rect.width * 1.02f; //calculo do tamanho do blur (ta multiplicado por 1,9 pq o tamanho da foto ta errado)
            photoSize[1] = photoSprite.rect.height * 1.02f;
            blurUI.GetComponent<Nova.UIBlock2D>().Size.XY = photoSize;

            if (photoVertical)
            {
                verticalPaper.SetActive(true);
                horizontalPaper.SetActive(false);
                photo.transform.position = new Vector3(-2.85f, -4.7f, 0);
                photoBG.transform.position = photo.transform.position;
            }
            else
            {
                horizontalPaper.SetActive(true);
                verticalPaper.SetActive(false);
                photo.transform.position = new Vector3(-2.79f, -0.9f, 0);
                photoBG.transform.position = photo.transform.position;
            }
            StartCoroutine(SetBlurLocation());
        }
        else
        {
            verticalPaper.SetActive(false);
            horizontalPaper.SetActive(false);
            blurUI.SetActive(false);
        }
       
    }

    public IEnumerator SetBlurLocation()
    {
        blurUI.SetActive(true);
        yield return new WaitForSeconds(0.05f); //Delay se n da merda, vai entender essa poha
        if (photoVertical)
        {
            Vector2 pos = new Vector2(-310, -201);
            blurUI.GetComponent<Nova.UIBlock2D>().Position.XY = pos;
        }
        else
        {
            Vector2 pos = new Vector2(-305, -94);
            blurUI.GetComponent<Nova.UIBlock2D>().Position.XY = pos;
        }
    }

}
