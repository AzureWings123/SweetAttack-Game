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
    private InputAction look; //Basic Mouse Position

    public Vector2 MovementInput { get; private set; } //Passes movement vector while not letting other functions change it
    public Vector2 LookInput { get; private set; } //Player mouse rotation

    //Bool signals
    public bool attackInput { get; private set; }
    public bool chSpellInput { get; private set; }

    private void Awake()
    {
        //Initalize controller and associated
        //Controls
        playerControls = new PlayerControls();

        look = playerControls.livecontrols.Look;
        move = playerControls.livecontrols.Move;
    }

    //Subscribe all movements here
    private void OnEnable()
    {
        //Turn on Boolean
        playerControls.livecontrols.attack.started += doAttackInput;
        playerControls.livecontrols.chspell.started += doChSpellInput; //Change Spell Input
        //Turn off Boolean
        playerControls.livecontrols.attack.canceled += stopAttackInput;
        playerControls.livecontrols.chspell.canceled += stopChSpellInput;
        playerControls.Enable();
    }

    //Unsubscribe all movement
    private void OnDisable()
    {
        playerControls.livecontrols.attack.started += doAttackInput;
        playerControls.livecontrols.chspell.started += doChSpellInput; //Change Spell Input

        playerControls.livecontrols.attack.canceled -= stopAttackInput;
        playerControls.livecontrols.chspell.canceled -= stopChSpellInput;

        playerControls.Disable();
    }

    public void Update()
    {
        MovementInput = move.ReadValue<Vector2>();
        LookInput = look.ReadValue<Vector2>();
    }

    //Here we bring out the true and false statements of whether or not the button was clicked
    //Though this can be done in a much simpler fashion, doing it this way prevents some edge
    //Cases that can occur from my experience.
    private void doAttackInput(InputAction.CallbackContext context) => attackInput = true;
    private void doChSpellInput(InputAction.CallbackContext context) => chSpellInput = true;

    //Here we send a false message to the caller.
    private void stopAttackInput(InputAction.CallbackContext context) => attackInput = false;
    private void stopChSpellInput(InputAction.CallbackContext context) => chSpellInput = false;

    //These are public stop fucntions which make is so that the button cannot be held down
    public void externalStopAttackInput() => attackInput = false;
    public void externalStopChSpellInput() => chSpellInput = false;
}
