using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public NavMeshAgent player;
    public InputActionReference leftClick, mousePos;
    private GameObject playerDestination;
    public bool canMove;
    [Header("Player Location")]
    public HouseLocations.actualHouseLocation actualLocation; //Comodo da casa onde o player se encontra atualmente
    [Header("Photo Info")]
    public Sprite photoSprite;
    public bool photoVertical;
    public int photoStage;
    public Color32 photoColor;
    private Animator anim;
    [Header("Retoque")]
    public Sprite truePhotoRet;
    public bool photoNeedRet;
    public int photoRetCount;
    public Sprite photoRet;
    public GameObject photoRetObj;
    public GameObject photoRetLocations; //prefab com os erros das fotos que precisam de retoque
    public Sprite photoRetSprite; //Sprite que fica no varal (Foto normal + "Falha")

    private UnityEngine.Vector2 lookDirection; //Direção do mouse em relação a arma
    private float lookAngle; //Angulo do mouse em relação a arma
    public UnityEngine.Vector3[] navMeshCorners;
    public int actualCorner =0;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        canMove = true;
        player = GetComponent<NavMeshAgent>();
        player.updateRotation = false;
        player.updateUpAxis = false;

        playerDestination = GameObject.Find("Player Destination");
        playerDestination.transform.position = this.transform.position; //só por garantia
    }

    private void Update() 
    {
        //player.SetDestination(playerDestination.transform.position);
        if(leftClick.action.IsPressed() && canMove)
        {
            Move();
        }

        if (!canMove)
        {
            anim.SetBool("Walk", false);
            playerDestination.transform.position = transform.position;
        }
        else if(UnityEngine.Vector3.Distance(transform.position, player.pathEndPosition) <0.8f)
        {
             anim.SetBool("Walk", false);
            
        }
        SetRotate();
    }

    

    public void SetRotate()
    {
        if(actualCorner < navMeshCorners.Length)
        {
            //UnityEngine.Vector2 newRot = navMeshCorners[actualCorner];
            float dist = UnityEngine.Vector3.Distance(transform.position, navMeshCorners[actualCorner]);
            if (dist < 1)
            {
                actualCorner++;
            }
            else
            {
                UnityEngine.Vector3 look = transform.InverseTransformPoint(navMeshCorners[actualCorner]);
                float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
                
                transform.Rotate(0, 0, angle);
            }
        }  
    }

    public void Move()
    {
        if (Time.timeScale == 1)
        {
            anim.SetBool("Walk", true);
            playerDestination.GetComponent<NavMeshAgent>().enabled = false;
            UnityEngine.Vector2 a = Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>());
            playerDestination.transform.position = a;
            playerDestination.GetComponent<NavMeshAgent>().enabled = true;
            actualCorner = 1;
            navMeshCorners = player.path.corners;
            player.SetDestination(playerDestination.transform.position);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HouseLocations>()!= null)
        {
            actualLocation = other.GetComponent<HouseLocations>().actualLocal;
        }
    }
}
