using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float characterSpeed;
    CharacterController characterController;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput);
        characterController.Move(movement * Time.deltaTime * characterSpeed);

        if (Input.GetKeyDown(KeyCode.E)) // Or space bar?
        {
            // Animate to collect
            // If materials on floor, pick up
            // Notify game manager to update loot
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Slow player down
            // Reduce detection radius
            // Maybe change motion animation
            // Maybe dim camera light onscreen
        }

    }
}
