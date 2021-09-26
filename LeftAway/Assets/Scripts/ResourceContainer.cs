using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceContainer
{
    private List<Resource> items;

    public int slotsAmount;


    public ResourceContainer(int slots)
    {
        items = new List<Resource>();
        slotsAmount = slots;
    }

    public void AddItem(Resource itemToAdd)
    {

        ResourceType typeToFind = itemToAdd.GetResourceType();
        int stackSize = itemToAdd.GetStackSize();
        int add_amount = itemToAdd.GetAmount();
        Resource foundResource = items.FirstOrDefault(i => ((i.GetResourceType()==typeToFind) && (i.GetAmount()!=stackSize)));
        if (foundResource!=null) { //Ресурс найден в инвентаре

            int cur_amount = foundResource.GetAmount();
            if (cur_amount+add_amount <= stackSize)
                foundResource.ChangeAmount(add_amount);
            else
            {
                int difference = stackSize - cur_amount;
                foundResource.ChangeAmount(difference);

                if (GetLength()<slotsAmount)
                    items.Add(new Resource(typeToFind,add_amount-difference));

            }
            
        }
        else {//Ресурс не найден в инвентаре
            if (GetLength()<slotsAmount)
                items.Add(itemToAdd);
      
        }
    }


    public int GetLength()  
    {
        return items.Count();
    }
    
    public Resource GetItem(int index)
    {
        if ((index<items.Count)&&(items[index]!=null))
            return items[index];
        else
            return null;
    }
    
    public void RemoveItem(Resource itemToRmv)
    {
        ResourceType typeToFind = itemToRmv.GetResourceType();
        Resource foundResource = items.FirstOrDefault(i => i.GetResourceType()==typeToFind);
        if (foundResource!=null) { //Ресурс найден в инвентаре
            foundResource.ChangeAmount(foundResource.GetAmount() * -1); //Обнуление количества 
        }
        else {//Ресурс не найден в инвентаре
            
            Debug.Log("Нет в инвентаре");
            
        }
    }
}
