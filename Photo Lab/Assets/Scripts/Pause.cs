using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePnl;
    public GameObject surePnl;

    private GameObject player, playerDest;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerDest = GameObject.Find("Player Destination");
    }
    public void PauseGame(bool pause) 
    {
        if (pause)
        {
            pausePnl.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            pausePnl.SetActive(false);
            Time.timeScale = 1f;
            playerDest.transform.position = player.transform.position;
            player.GetComponent<PlayerScript>().player.SetDestination(player.transform.position);
        }
    }

    public void OpenAreUSurePnl() 
    {
        surePnl.GetComponent<Animator>().SetTrigger("OpenPanel");
    }
    public void AreYouSure(bool sure) 
    {
        if (sure)
        {
            Application.Quit();
        }
        else
        {
            surePnl.GetComponent<Animator>().SetTrigger("ClosePanel");
        }
    }

}
