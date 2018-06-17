using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlace : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                Vector3 hitPos = hit.point;
                var texture = PlacementUtil.GetMainTexture(hitPos);
                Debug.Log("Hit texture: " + texture.ToString());
            }
        }
    }
}