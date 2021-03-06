using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Tappable
{
    public enum Status 
    {
        construction,
        working,
        needresources
    }

    private Status status;

    private int level;

    [SerializeField] private UI_Manager ui_Manager;
    public ResourceContainer inventory;

   
    public int startInvSlots = 2;

     public override void Tap()
    {
        //Open menu plus update inventory to show

        ui_Manager.SetTitle(this.name + " lvl." + level);
        ui_Manager.SetStatus(status);
        ui_Manager.OpenMenu(this);
    }

    public override void ClearTap()
    {
        ui_Manager.CloseMenu();
    }

    private void Start() {
        inventory = new ResourceContainer(startInvSlots);
    }

    public Status GetStatus()
    {
        return status;
    }

    public void SetStatus(Status toStatus)
    {
        status = toStatus;
    }
}
