using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float smoothing;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 playerInput;
    [SerializeField] private Vector2 playerVelocity;
    [SerializeField] private Vector2 playerTargetPosition;
    [SerializeField] private Vector2 playerPosition;

    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);

        playerInput.Normalize();

        playerTargetPosition = playerPosition + (playerInput * playerSpeed);

        playerTransform.position = Vector2.SmoothDamp(playerPosition, playerTargetPosition, ref playerVelocity, smoothing);

        if (playerInput.x == 0 && Mathf.Abs(playerVelocity.x) < 0.01f)
        {
            playerVelocity.x = 0;
        }
        if (playerInput.y == 0 && Mathf.Abs(playerVelocity.y) < 0.01f)
        {
            playerVelocity.y = 0;
        }

    }


}
