using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get private set is used to get the properties of public
    //While also keeping working to its normal protection level
    //Regions are used to keep the code clean
    public PlayerStateMachine stateMachine {get; private set;}
    public Rigidbody2D rb { get; private set; }

    //Basic scripts needed for actions
    #region Dependency Scripts


    #endregion
    //All Substates needed
    public PlayerIdleState idleState{get; private set;}
    #region States

    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }
}
