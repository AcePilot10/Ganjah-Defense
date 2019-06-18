using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefenseButton : MonoBehaviour
{
    public void PlaceDefense()
    {
        FindObjectOfType<DefensePlacement>().PlaceObject();
    }

    public void CancelPlacing()
    {
        FindObjectOfType<DefensePlacement>().CancelPlacing();
    }
}