using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    protected Peasant peasant;
    protected StateMachine stateMachine;

    protected State(Peasant peasant, StateMachine stateMachine)
    {
        this.peasant = peasant;
        this.stateMachine = stateMachine;
    }

public virtual void Enter()
{
    
}

public virtual void LogicUpdate()
{

}

public virtual void PhysicsUpdate()
{

}

public virtual void Exit()
{

}
}
