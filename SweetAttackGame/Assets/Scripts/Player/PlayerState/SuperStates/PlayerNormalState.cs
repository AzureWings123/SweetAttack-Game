using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerState
{
    public PlayerNormalState(Player player, PlayerStateMachine stateMachine)
                            :base(player, stateMachine){}
    
    protected Vector2 moveInput;


    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }


    public override void Exit()
    {
        base.Exit();
    }

    
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Initialize connections between handler and player
        moveInput = player.controllerHandler.MovementInput; 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
