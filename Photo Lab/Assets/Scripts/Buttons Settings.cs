using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonsSettings : MonoBehaviour
{
    public bool nedUpdate;
    public bool noNeedSettings; //botoes q n precisam de ajeitar o hitbox com a imagem; por hora só o do painel de ctz
    [Header("SFX")]
    public AudioClip buttonClickSound;
    void Start()
    {
        if (!noNeedSettings) 
        { 
            this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso só deixa o botão do formato que é a imagem
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nedUpdate) 
        {
            //this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso só deixa o botão do formato que é a imagem
        }
    }

    public void OnclickSound() 
    {
        //Sounds.instance.PlaySingle(buttonClickSound);
    }

}
