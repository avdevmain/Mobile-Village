using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapControl : MonoBehaviour
{

    public Camera cam;
    private Peasant selectedPeasant;

    // Start is called before the first frame update
    void Start()
    {
        selectedPeasant = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Peasants");
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 20f, mask))
        {
            Debug.Log("Здарова  " + hit.transform.name);
            ChoosePeasant(hit.transform.GetComponent<Peasant>());
        }
    
        }


    }

    void ChoosePeasant(Peasant peasant)
    {
        if (selectedPeasant)
            selectedPeasant.MakeHighlited(false);
        selectedPeasant = peasant;
        selectedPeasant.MakeHighlited(true);
    }

    
}
