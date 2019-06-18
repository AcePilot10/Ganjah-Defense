using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableWindow : WindowBase {

    public bool isDragging = false;
    public Rigidbody rb;

    public virtual void BeginDrag()
    {
        isDragging = true;
    }

    public virtual void EndDrag()
    {
        isDragging = false;
    }

    protected virtual void Update()
    {
        if (isDragging)
        {
            rb.position = Input.mousePosition;
        }
    }
}
