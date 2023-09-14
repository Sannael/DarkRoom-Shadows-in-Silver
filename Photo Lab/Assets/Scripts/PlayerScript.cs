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
    public InputActionReference rightClick, mousePos;
    private GameObject playerDestination;

    private void Start() 
    {
        player = GetComponent<NavMeshAgent>();
        player.updateRotation = false;
        player.updateUpAxis = false;

        playerDestination = GameObject.Find("Player Destination");
        playerDestination.transform.position = this.transform.position; //só por garantia
    }

    private void Update() 
    {
        player.SetDestination(playerDestination.transform.position);
        //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>())); 
        if(rightClick.action.IsPressed())
        {
            Move();
        }
    }

    public void Move()
    {   
        UnityEngine.Vector2 a = Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>());
        playerDestination.transform.position = a;
    }
}
