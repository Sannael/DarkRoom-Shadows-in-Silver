using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //Isso s� deixa o bot�o do formato que � a imagem
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
