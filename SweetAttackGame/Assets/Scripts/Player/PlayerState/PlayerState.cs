using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the basis for a state machine
//All states will follow this format
//Leave any physics to physics update
//And everything else to logic update
//Not a mono behavior since it is connected to all other 
//Super States and substates


public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;

    }

    public virtual void Enter()
    {
        DoChecks();
    }
    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        //This is optional
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
