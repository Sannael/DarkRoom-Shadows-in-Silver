using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    [Header("FruFru")]
    public GameObject hover;
    public GameObject objLight;

    private Collider2D mouseCol;
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
        mouseCol = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if(player.GetComponent<PlayerScript>().canMove == true)
        {
            if (mouseCol != null)
            {
                if(mouseCol.gameObject.tag != ("Work Space"))
                {
                    \
                }
            }
            if(GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && player.GetComponent<PlayerScript>().actualLocation == actualLocation)
            {
                if (canUse)
                {
                    hover.SetActive(true);
                    CursorScript.cursorInstace.ChangeCursor("Select");
                    if (Input.GetMouseButtonDown(0))
                    {
                        MouseClick();
                    }
                }
                else
                {
                    hover.SetActive(false);
                    CursorScript.cursorInstace.ChangeCursor("Idle");
                }
            }
        }
        
            
        if (actualLocation == player.GetComponent<PlayerScript>().actualLocation) //Checa se o Player esta no mesmo comodo que o objeto
        {
            canUse = CheckPlayerDistance();
        }
        else
        {
            canUse = false;
        }

        if (canUse) 
        {
            objLight.SetActive(true);
            //this.GetComponent<SpriteRenderer>().color = new Color32(144, 144, 144, 255);   
        }
        else
        {
             objLight.SetActive(false);
            //this.GetComponent<SpriteRenderer>().color = Color.white;
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
    public void MouseClick()
    {
        GameObject.Find("Game Controller").GetComponent<GameControllerScript>().seeQuestPointer = false;
        player.GetComponent<PlayerScript>().canMove = false;
        OpenPnl(workPanel);
        CursorScript.cursorInstace.ChangeCursor("Idle");
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
        hover.SetActive(false);
        CursorScript.cursorInstace.ChangeCursor("Idle");
    }


}
