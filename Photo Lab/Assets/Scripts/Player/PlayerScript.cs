using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerScript : MonoBehaviour
{
    public NavMeshAgent player;
    public InputActionReference leftClick, mousePos;
    private GameObject playerDestination;
    public bool canMove;
    [Header("Player Location")]
    public HouseLocations.actualHouseLocation actualLocation; //Comodo da casa onde o player se encontra atualmente

    private void Start()
    {
        canMove = true;
        player = GetComponent<NavMeshAgent>();
        player.updateRotation = false;
        player.updateUpAxis = false;

        playerDestination = GameObject.Find("Player Destination");
        playerDestination.transform.position = this.transform.position; //só por garantia
    }

    private void Update() 
    {
        player.SetDestination(playerDestination.transform.position);
        if(leftClick.action.IsPressed() && canMove)
        {
            Move();
        }

        if (!canMove)
        {
            playerDestination.transform.position = transform.position;
        }
    }

    public void Move()
    {
        playerDestination.GetComponent<NavMeshAgent>().enabled = false;
        UnityEngine.Vector2 a = Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>());
        playerDestination.transform.position = a;
        playerDestination.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HouseLocations>()!= null)
        {
            actualLocation = other.GetComponent<HouseLocations>().actualLocal;
        }
    }
}
