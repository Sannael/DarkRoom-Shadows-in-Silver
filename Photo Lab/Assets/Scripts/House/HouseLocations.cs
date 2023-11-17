using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLocations : MonoBehaviour
{
    public enum actualHouseLocation //Armazena todfos os comodos da casa
    {
        Store, Hall, Kitchen, Corridor, Lab, Drying, Bedroom, Bathroom
    }
    public actualHouseLocation actualLocal;

    /*public static HouseLocations houseLocationsInstance;

    public void Awake()
    {
        houseLocationsInstance = this;        
    }*/

}
