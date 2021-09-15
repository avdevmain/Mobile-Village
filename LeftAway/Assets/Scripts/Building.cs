using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public enum Status 
    {
        construction,
        working,
        needresources
    }

    private Status status;

    public ResourceContainer inventory;

    private void Start() {
        inventory = new ResourceContainer();
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
