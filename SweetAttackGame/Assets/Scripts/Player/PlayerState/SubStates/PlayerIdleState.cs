using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerNormalState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }
    // Start is called before the first frame update
    
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        Debug.Log("test state active");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (attackInput)
        { 
            player.controllerHandler.externalStopAttackInput();
            player.spell.castSpell();
        }

        if (changeSpell)
        {
            player.controllerHandler.externalStopChSpellInput();
            player.spell.changeSpell();
        }



        if (moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.playerMovement.look(lookInput);
        player.playerMovement.movement(moveInput);
    }
}
