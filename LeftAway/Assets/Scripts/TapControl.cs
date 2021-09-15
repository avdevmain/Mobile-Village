using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapControl : MonoBehaviour
{

    public Camera cam;
    private Peasant selectedPeasant;

    public GameObject cancel_bttn;

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
            LayerMask mask = LayerMask.GetMask("Tappable");
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 20f, mask))
        {

            Debug.Log("Попал в какой-то интерактивный объект");
            //ChoosePeasant(hit.transform.GetComponent<Peasant>());
        }
    
        }


    }

    void ChoosePeasant(Peasant peasant)
    {
        if (selectedPeasant)
            selectedPeasant.MakeHighlited(false);
        selectedPeasant = peasant;
        selectedPeasant.MakeHighlited(true);

        if (!cancel_bttn.activeSelf)
        {
            cancel_bttn.SetActive(true);
            cancel_bttn.GetComponent<Button>().onClick.AddListener(() => CancelPeasantSelection());
        }

        
    }

    public void CancelPeasantSelection()
    {
        if (selectedPeasant)
        {
            selectedPeasant.MakeHighlited(false);
            selectedPeasant = null;
        }

        cancel_bttn.SetActive(false);
        cancel_bttn.GetComponent<Button>().onClick.RemoveAllListeners();
        
    }

    
}
