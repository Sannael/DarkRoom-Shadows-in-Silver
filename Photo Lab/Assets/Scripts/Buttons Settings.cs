using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso só deixa o botão do formato que é a imagem
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
