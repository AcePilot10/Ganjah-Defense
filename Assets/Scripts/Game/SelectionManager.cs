using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public ISelectable selected;

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
                    if (hit.collider.GetComponent<ISelectable>() != null)
                    {
                        ISelectable selectableDefense = hit.collider.GetComponent<ISelectable>();
                        if (selectableDefense != selected)
                        {
                            SelectDefense(selectableDefense);
                        }
                        else
                        {
                            DeselectDefense();
                        }
                    }
                }
            }
        }
    }

    public void SelectDefense(ISelectable defense)
    {
        if (selected != null) DeselectDefense();
        selected = defense;
        selected.Select();
    }

    public void DeselectDefense()
    {
        try
        {
            selected.Deselect();
        }
        catch (MissingReferenceException) {}
        selected = null;
    }

    private bool CanSelect()
    {
        return !DefensePlacement.instance.isPlacing;
    }
}