using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;

public class Controller2D : MonoBehaviour
{
    
    public float standardMovementSpeed = 5.0f;
    public float stealthMovementSpeed = 2.3f;
    public float DetectionRadius
    {
        get {return detectionRadius;}
    }
    [SerializeField] float standardDetectionRadius = 2.0f;
    private float detectionRadius;
    private float stealthDetectionRadius = 1.0f;
    float movementSpeed = 5.0f;
     Rigidbody2D rb2D;
    Vector2 movement;
    float horizontalInput;
    float verticalInput;

    // Get animation reference
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        detectionRadius = standardDetectionRadius;
    }

    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        // movement = new Vector2(horizontalInput, verticalInput).normalized;
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey(KeyCode.W))
            moveY = 1f;
        if (Input.GetKey(KeyCode.S))
            moveY = -1f;
        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D))
            moveX = 1f;
        movement = new Vector2(moveX, moveY).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            detectionRadius = stealthDetectionRadius;
            movementSpeed = stealthMovementSpeed;
        }
        else
        {
            detectionRadius = standardDetectionRadius;
            movementSpeed = standardMovementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Attack or harvest
        }
        // Set animation according to movement
    }

    void FixedUpdate()
    {
        rb2D.velocity = movement * movementSpeed;
    }

    


#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
#endif
}
