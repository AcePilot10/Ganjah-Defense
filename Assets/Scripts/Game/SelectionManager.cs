using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public DefenseBase selected;

    private void Update()
    {
        CheckSelection();
    }

    private void CheckSelection()
    {
        if (CanSelect())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    //Debug.Log("Checking selection!");
                    if (hit.collider.GetComponent<DefenseBase>() != null)
                    {
                        DefenseBase defense = hit.collider.GetComponent<DefenseBase>();
                        if (selected != defense)
                        {
                            SelectDefense(defense);
                        }
                        else
                        {
                            DeselectDefense();
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Cannot select!");
        }
    }

    public void SelectDefense(DefenseBase defense)
    {
        Debug.Log("Selected " + defense.name);
        selected = defense;
        selected.Select();
    }

    public void DeselectDefense()
    {
        Debug.Log("Deselected " + selected.name);
        selected.Deselect();
        selected = null;
    }

    private bool CanSelect()
    {
        return !DefensePlacement.instance.isPlacing;
    }
}