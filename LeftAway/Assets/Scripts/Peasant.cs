using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EPOOutline;

public class Peasant : Tappable
{
    [SerializeField] private Vector3 desiredPosition;

    NavMeshAgent agent;
    Outlinable outline;

    Color blueColor = new Color32(0,235,255,255);

    private ResourceContainer inventory;

    public StateMachine stateMachine;

    public IdleState idle;


    private int peasantInvSlots = 3;
    
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        outline = GetComponent<Outlinable>();
    }

    private void Start()
    {
        stateMachine = new StateMachine();
        inventory = new ResourceContainer(peasantInvSlots);

        idle = new IdleState(this, stateMachine);

        stateMachine.Initialize(idle);
    }
    
    public void MakeHighlited(bool value)
    {
        if (value)
        {
            outline.enabled = true;
            outline.OutlineParameters.Color = blueColor;
        }
        else
        {
            outline.enabled = false;
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

    public override void Tap()
    {
        MakeHighlited(true);
    }

    public override void ClearTap()
    {
        MakeHighlited(false);
    }


}
