using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Store storeScript;
    public PlayerScript ps;
    public int photoFinal;

    private void Update()
    {
        if(ps.photoStage == photoFinal && storeScript.prefabCostumerScript.costumerAction ==1)
        {
            storeScript.prefabCostumerScript.costumerAction = 2;
        }
    }
}
