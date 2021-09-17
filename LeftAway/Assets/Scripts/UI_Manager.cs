using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] GameObject menu_panel;

    [SerializeField] private TMP_Text building_title;

    [SerializeField] private TMP_Text status;

    [SerializeField] private Transform inv_grid; //inventory obj with grid layout group


    public void OpenMenu()
    {
        if (!menu_panel.activeSelf)
            menu_panel.SetActive(true);
    }

    public void CloseMenu()
    {
        menu_panel.SetActive(false);
    }

   public void SetTitle(string text)
   {
       building_title.text = text;
   }

   public void SetupInventory(Building building)
   {
       for (int i = 0; i< building.slotsAmount; i++)
       {
           //Create inventory slot, fill it with item icon and write resource amount
       }
   }

    public void SetStatus(Building.Status status)
    {
        status.ToString();
    }

}
