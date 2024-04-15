using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Credits : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(BackToMainMenu());
    }

    public void BackToMenuNow()
    {
        ManagerScene scenem = ManagerScene.sceneManagerInstance;
        scenem.LoadScene(0);
    }
    
    public IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(30f);
        ManagerScene scenem = ManagerScene.sceneManagerInstance;
        scenem.LoadScene(0);
    }

}
