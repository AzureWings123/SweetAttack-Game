using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Player player;

    public void movement(Vector2 movementDirection)
    {
        //Moves object
        player.rb.MovePosition(player.rb.position + movementDirection * player.moveSpeed * Time.fixedDeltaTime);
    } 
}
