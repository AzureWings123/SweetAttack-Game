using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //get private set is used to get the properties of public
    //While also keeping working to its normal protection level
    //Regions are used to keep the code clean
    public PlayerStateMachine stateMachine { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerControllerHandler controllerHandler { get; private set; }
    public Camera cam;
    //Basic scripts needed for actions
    #region Dependency Scripts
    [SerializeField] public PlayerMovement playerMovement;
    [SerializeField] public Spell spell;
    [SerializeField] public rig rig;
    #endregion

    #region States
    //All Substates needed
    public PlayerIdleState idleState { get; private set; }
    public PlayerMovementState moveState { get; private set; }
    #endregion

    public float moveSpeed = 7f;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine);
        moveState = new PlayerMovementState(this, stateMachine);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controllerHandler = GetComponent<PlayerControllerHandler>();
        stateMachine.Initalize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
}
