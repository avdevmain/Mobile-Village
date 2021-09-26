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

    [SerializeField] private GameObject inv_slot_prefab;

    private List<GameObject> inventorySlots;

    private void Start() {
        inventorySlots = new List<GameObject>();
    }
    public void OpenMenu(Building building)
    {
        if (!menu_panel.activeSelf)
            {menu_panel.SetActive(true);
            SetupInventory(building);
            }
    }

    public void CloseMenu()
    {
        menu_panel.SetActive(false);
        inventorySlots.Clear();

        foreach (Transform child in inv_grid)
            Destroy(child.gameObject);
    }

   public void SetTitle(string text)
   {
       building_title.text = text;
   }

   public void SetupInventory(Building building)
   {
       for (int i = 0; i< building.inventory.slotsAmount; i++)
       {
           //Create inventory slot, fill it with item icon and write resource amount
            GameObject newSlot = Instantiate(inv_slot_prefab, inv_grid);
            newSlot.GetComponent<inv_slot>().SetupSlot(building.inventory.GetItem(i));
            inventorySlots.Add(newSlot); //Unbelivevably bad code
       }
   }

    public void SetStatus(Building.Status status)
    {
        status.ToString();
    }

}
