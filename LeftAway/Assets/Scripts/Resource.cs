using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Resource
{
    private ResourceType type;

    private int amount;

    public Resource(ResourceType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }

    public ResourceType GetResourceType()
    {
        return type;
    }


    public void ChangeAmount(int value)
    {
        amount += value;
    }

    public int GetAmount()
    {
        return amount;
    }
}


public enum ResourceType
{
    timber,
    wood,
    stone,
    wood_hammer,
    wood_axe

}
