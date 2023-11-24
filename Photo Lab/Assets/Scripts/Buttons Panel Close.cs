using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanelClose : MonoBehaviour
{
    public int firstStage;
    public int lastStage;// Ultimo estado que o painel pode realizar (Seguir numeros do  photo infos script)
    public Button btnClose;
    private GameObject panel;
    private bool speaking;
    private Store storeScript;


    private void Start()
    {
        panel = this.gameObject;
        try { storeScript = panel.GetComponent<Store>(); }
        catch { speaking = false; }

    }
    void Update()
    {
        if(storeScript != null)
        {
            speaking = storeScript.speaking;
        }
        PlayerScript ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        if (speaking)
        {
            btnClose.interactable = false;
        }
        else
        {
            if(ps.photoSprite == null)
            {
                btnClose.interactable = true;
            }
            else if (ps.photoStage > lastStage || ps.photoStage < firstStage)
            {
                btnClose.interactable = true;
            }
            else
            {
                btnClose.interactable = false;
            }
        }
        
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        GameObject.Find("Camera Follow").GetComponent<CameraFollow>().backToPos = true;
        GameObject.Find("Player").GetComponent<PlayerScript>().canMove = true;
    }
}
