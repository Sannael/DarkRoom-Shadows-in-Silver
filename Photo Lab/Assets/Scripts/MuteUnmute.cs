using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    public AudioMixer masterAudio;
    public Button anotherButton; //no Mute é o unmute e vice versa
    public void MuteUnmuteGame(bool mute)
    {
        if (!mute)
        {
            masterAudio.SetFloat("Master Volume", 0); //Ver valor do som geral
        }
        else
        {
            masterAudio.SetFloat("Master Volume", -80); //Jogo não ta mutandooooooooo
        }
        this.GetComponent<Button>().interactable = false;
        anotherButton.interactable = true;
    }
}
