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
    private GameObject point;
    public InputActionReference click, mousePos;

    private void Start() 
    {
        player = GetComponent<NavMeshAgent>();
        player.updateRotation = false;
        player.updateUpAxis = false;

        point = GameObject.Find("Point");
    }

    private void Update() 
    {
        player.SetDestination(point.transform.position);
        //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>())); 
        if(click.action.IsPressed())
        {
            Click();
        }
    }

    public void Click()
    {   
        UnityEngine.Vector2 a = Camera.main.ScreenToWorldPoint(mousePos.action.ReadValue<UnityEngine.Vector2>());
        point.transform.position = a;
    }
}
