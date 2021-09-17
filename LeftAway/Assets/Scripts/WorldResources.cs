using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResources : Tappable
{
    
    [SerializeField] private int amount;

    public ResourceType type;

    [SerializeField] private Building townhall;

    public override void Tap()
    {
        base.Tap();

        townhall.inventory.AddItem(new Resource(type, amount));
 
    }

    public override void ClearTap()
    {
        
    }


}
