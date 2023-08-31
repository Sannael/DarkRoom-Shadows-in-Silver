using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public static ManagerScene sceneManagerInstance;
    
    private void Awake() 
    {
        sceneManagerInstance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
