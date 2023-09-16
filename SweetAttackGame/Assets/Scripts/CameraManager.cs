using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // This script is ment to contorl the camera following the player around

    [Tooltip("Will be auto set to a GameObject named 'Player' can manually set it to something else in the inspector")]
    [SerializeField] private GameObject player;

    [Tooltip("How much should the camera focus on the direction of the player's mouse.  Opposed to being centered on the player.  0 is centered on the player and 0.5 is inbetween the player and the mouse.")]
    [Range(0.0f, 0.5f)]
    [SerializeField] private float CameraLookAheadAmount = 0.15f;
    private float cameraZOffset = -10;

    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
            if(player == null)
            {
                Debug.LogWarning("The 'Player' prefab is not present in the scene");
            }
        }
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 finalPosition = Vector2.Lerp(GetPlayerPosition(), GetCursorPosition(), CameraLookAheadAmount);
        finalPosition.z = cameraZOffset;

        Debug.Log("Player Position: " + GetPlayerPosition() + "\nCursor Position: " + GetCursorPosition());
        
        this.transform.position = finalPosition;
    }

    private Vector2 GetPlayerPosition()
    {
        Vector2 playerPosition = player.transform.position;

        return playerPosition;
    }

    private Vector2 GetCursorPosition()
    {
        return  player.GetComponent<Player>().cam.ScreenToWorldPoint(player.GetComponent<PlayerControllerHandler>().LookInput);
    }
}
