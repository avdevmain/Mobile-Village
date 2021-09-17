using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceContainer
{
    private List<Resource> items;

    //public int maxStacks;


    public ResourceContainer()
    {
        items = new List<Resource>();
    }

    public void AddItem(Resource itemToAdd)
    {

        ResourceType typeToFind = itemToAdd.GetResourceType();
        Resource foundResource = items.FirstOrDefault(i => i.GetResourceType()==typeToFind);
        if (foundResource!=null) { //Ресурс найден в инвентаре
            foundResource.ChangeAmount(itemToAdd.GetAmount());
            
        }
        else {//Ресурс не найден в инвентаре
            items.Add(itemToAdd);
        }
    }

    public int GetLength()  
    {
        return items.Count();
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
