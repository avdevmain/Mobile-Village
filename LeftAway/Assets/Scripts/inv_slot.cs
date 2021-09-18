using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class inv_slot : MonoBehaviour
{



    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amount;

    public void SetupSlot(Resource resource)
    {

        if (resource==null)
        {
            icon.sprite = null;
            amount.text = "";

        }
        else
        {
        amount.text = resource.GetAmount() + "/" + resource.GetStackSize();

        string type = "";
        switch(resource.GetResourceType())
        {
            case ResourceType.timber:
                type = "timber_inv";
            break;
            case ResourceType.wood:
                type = "wood_inv";
            break;
            case ResourceType.stone:
                type = "stone_inv";
            break;
        }

        icon.sprite = Resources.Load<Sprite>(type);
        }
    }

}
