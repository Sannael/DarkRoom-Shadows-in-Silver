using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    public GameObject player;

    [Header("Player Distance")]
    [Tooltip("Distancia Máxima que o player deve estar do objeto, separei em x e y pra poder alterar em cada objeto independente da sua posição, rotação e forma. LEVANDO SEMPRE EM CONTA O MEIO DO OBJETO")]
    public float maxDistX;
    public float maxDistY;

    [Header("Player can use?")]
    public HouseLocations.actualHouseLocation actualLocation;
    public bool canUse;
    public float disX, disY;

    [Header("Work Panel")]
    public GameObject workPanel;
        
    void Start()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (actualLocation == player.GetComponent<PlayerScript>().actualLocation) //Checa se o Player esta no mesmo comodo que o objeto
        {
            canUse = CheckPlayerDistance();
        }
        else
        {
            canUse = false;
        }

        if (canUse)
            this.GetComponent<SpriteRenderer>().color = Color.red;
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            CursorScript.cursorInstace.ChangeCursor("Idle");
        }
            


    }
    [ContextMenu("Distance")]
    public bool CheckPlayerDistance()
    {
        disX = transform.position.x - player.transform.position.x;
        disY = transform.position.y - player.transform.position.y;
        if (disX < 0)
        {
            disX =  disX * -1; //Inverte o valor caso seja negativo 
        }

        if(disY < 0)
        {
            disY = disY * -1;
        }

         return disX < maxDistX && disY < maxDistY ? true : false;
    }


    public void OnMouseOver()
    {
        if (canUse)
        {
            CursorScript.cursorInstace.ChangeCursor("Select");

            if (player.GetComponent<PlayerScript>().leftClick.action.IsPressed())
            {
                player.GetComponent<PlayerScript>().canMove = false;
                OpenPnl(workPanel);
            }
        } 
    }

    public void OpenPnl(GameObject panel)
    {
        panel.SetActive(true);
        GameObject.Find("Camera Follow").GetComponent<CameraFollow>().backToPos = false;
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    

    public void OnMouseExit()
    {
       CursorScript.cursorInstace.ChangeCursor("Idle");
    }


}
