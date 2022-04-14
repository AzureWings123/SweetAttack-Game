using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerState
{
    public PlayerNormalState(Player player, PlayerStateMachine stateMachine)
                            :base(player, stateMachine){}
    
    protected Vector2 moveInput;
    protected Vector2 lookInput;

    protected bool attackInput;
    protected bool changeSpell;

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
        attackInput = player.controllerHandler.attackInput;
        changeSpell = player.controllerHandler.chSpellInput;
        moveInput = player.controllerHandler.MovementInput; 
        lookInput = player.controllerHandler.LookInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
