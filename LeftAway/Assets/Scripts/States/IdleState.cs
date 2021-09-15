using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Peasant peasant, StateMachine stateMachine) : base(peasant, stateMachine)
{
}

public override void Enter()
{
    Debug.Log("Привет, я жду =)");
}

public override void Exit()
{

}

public override void LogicUpdate()
{

}

public override void PhysicsUpdate()
{
   
}
}
