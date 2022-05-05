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
        player.rb.MovePosition(player.rb.position + movementDirection.normalized * player.moveSpeed * Time.fixedDeltaTime);
        player.rig.ldRb.MovePosition(player.rb.position + movementDirection.normalized * player.moveSpeed * Time.fixedDeltaTime);
    }

    public void look(Vector2 lookInput)
    {
        Vector2 mousepos = player.cam.ScreenToWorldPoint(lookInput);

        //Rotates Object
        Vector2 lookDir = mousepos - player.rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        player.rig.ldRb.rotation = angle;
    } 
}
