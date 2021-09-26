using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResources : Tappable
{
    public float respawnTime;
    [SerializeField] private int amount;

    public ResourceType type;

    [SerializeField] private Building townhall;

    public Collider collider;
    public GameObject model;

    public override void Tap()
    {
        base.Tap();

        townhall.inventory.AddItem(new Resource(type, amount));
        
        collider.enabled = false;
        model.SetActive(false);

        StartCoroutine(Respawn());
    }

    public override void ClearTap()
    {
        
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSecondsRealtime(respawnTime);
        collider.enabled = true;
        model.SetActive(true);
    }

}
