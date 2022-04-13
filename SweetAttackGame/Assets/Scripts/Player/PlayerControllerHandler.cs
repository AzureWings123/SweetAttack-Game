using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This is the basis for player input
// In here we will subscribe and unsubscribe buttons
// Through this we can how the player can interact with controls
// And make it more accessible as a whole

public class PlayerControllerHandler : MonoBehaviour
{
    private PlayerControls playerControls;

    private InputAction move; //Basic Left-Right-Up-Down movement

    public Vector2 MovementInput {get; private set;} //Passes movement vector while not letting other functions change it

    private void Awake() 
    {
        //Initalize controller and associated
        //Controls
        playerControls = new PlayerControls();

        move = playerControls.livecontrols.Move;    
    }

    //Subscribe all movements here
    private void OnEnable() 
    {
        playerControls.Enable();
    }

    //Unsubscribe all movement
    private void OnDisable() {
        playerControls.Disable();
    }

    public void Update()
    {
        MovementInput = move.ReadValue<Vector2>();
    }
}
