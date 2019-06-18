using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseOutline : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private bool isSelected = false;

    public void Select()
    {
        Debug.Log("SELECTED OBJECT!");
        FindObjectOfType<DefensePlacement>().SetIsMoving(true);
        isSelected = true;
    }

    public void Deselect()
    {
        Debug.Log("DESELECTED OBJECT!");
        FindObjectOfType<DefensePlacement>().SetIsMoving(false);
        isSelected = false;
    }

    void Update()
    {
        if (!isSelected)
        {
            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;
                    if (obj.GetComponent<DefenseOutline>() != null)
                    {
                        Select();
                    }
                }
            }
        }
        else
        {
            //If we are moving the outline and left click is released
            if (!Input.GetMouseButton(0))
            {
                Deselect();
            }
        }
    }
}