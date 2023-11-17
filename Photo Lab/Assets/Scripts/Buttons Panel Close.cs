using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanelClose : MonoBehaviour
{
    public int lastStage;// Ultimo estado que o painel pode realizar (Seguir numeros do  photo infos script)
    public Button btnClose;
    private GameObject panel;
    private PhotoInfos photoInfo;

    private void Start()
    {
        panel = this.gameObject;
        try {photoInfo = GameObject.FindAnyObjectByType<PhotoInfos>(); }
        catch { }
    }
    void Update()
    {
        if(photoInfo.actualStage > lastStage)
        {
            btnClose.interactable = true;
        }
        else
        {
            btnClose.interactable = false;
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        GameObject.Find("Camera Follow").GetComponent<CameraFollow>().backToPos = true;
        GameObject.Find("Player").GetComponent<PlayerScript>().canMove = true;
    }
}
