using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerNormalState
{
    public PlayerMovementState (Player player, PlayerStateMachine stateMachine): base(player, stateMachine){}
    
    // Start is called before the first frame update
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        Debug.Log("move state active");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (moveInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.playerMovement.movement(moveInput);
    }
}