using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonsSettings : MonoBehaviour
{
    public bool nedUpdate;
    
    [Header("SFX")]
    public AudioClip buttonClickSound;
    public AudioMixer masterAudio;
    private bool isMute;
    void Start()
    {
        isMute = false;
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso s� deixa o bot�o do formato que � a imagem
    }

    // Update is called once per frame
    void Update()
    {
        if (nedUpdate) 
        {
            //this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso s� deixa o bot�o do formato que � a imagem
        }
    }

    public void OnclickSound() 
    {
        Sounds.instance.PlaySingle(buttonClickSound);
    }

    public void MuteUnmuteGame() 
    {
        if (isMute) 
        {
            masterAudio.SetFloat("Master Volume", 0); //Ver valor do som geral
        }
        else 
        {
            masterAudio.SetFloat("Master", -80); //Jogo n�o ta mutandooooooooo
        }

        isMute = !isMute;

    }
}
