using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Resource
{
    private ResourceType type;

    private int amount;

    private int stackSize;

    public Resource(ResourceType type, int amount)
    {
        this.type = type;
        this.amount = amount;

        switch (type)
        {
            case ResourceType.timber:
            case ResourceType.wood:
            case ResourceType.stone:
                stackSize = 16;
            break;
            case ResourceType.wood_hammer:
            case ResourceType.wood_axe:
                stackSize = 1;
            break;

            default:
            stackSize = 0;
            break;
        }

        if (amount > stackSize)
        {
            Debug.LogError("Amount of resource exceeds stack size limit!");
        }
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
