using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Peasant : MonoBehaviour
{
    [SerializeField] private Vector3 desiredPosition;

    NavMeshAgent agent;

    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    
    public void MakeHighlited(bool value)
    {
        if (value)
        {
            //Выделить цветом
        }
        else
        {
            //Убрать выделение
        }
    }
   

     void SetDestination(Vector3 chosenPosition) {

        desiredPosition = chosenPosition;
        
        if (Vector3.Distance(this.transform.position, desiredPosition) > 0.1f)
        {
            agent.destination = desiredPosition;
            
        }
        else
        {
            desiredPosition = this.transform.position;
        }
        
        
    }

}
