using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapControl : MonoBehaviour
{

    public Camera cam;
    private Peasant selectedPeasant;

    private Tappable tappedObj;

    void Start()
    {
        selectedPeasant = null;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Tappable");
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 20f, mask))
        {

            if (tappedObj)
            {
                tappedObj.ClearTap();
                tappedObj = null;
            }

            tappedObj = hit.transform.GetComponent<Tappable>();
            tappedObj.Tap();
        }
        else
        {
            if (tappedObj)
            {
                tappedObj.ClearTap();
                tappedObj = null;
            }
        }
    
        }


    }
    
}
