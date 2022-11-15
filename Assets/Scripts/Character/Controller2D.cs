using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using UnityEngine.Rendering.Universal;
using System;
public class Controller2D : MonoBehaviour
{
    public static Action OnFirstMovement;
    public float standardMovementSpeed = 5.0f;
    public float stealthMovementSpeed = 2.3f;
    public float DetectionRadius
    {
        get {return detectionRadius;}
    }
    [SerializeField] float standardDetectionRadius = 2.0f;
    [SerializeField] GameObject gatheringStick;
    private float detectionRadius;
    private float stealthDetectionRadius = 1.0f;
    float movementSpeed = 5.0f;
     Rigidbody2D rb2D;
    Vector2 movement;
    float horizontalInput;
    float verticalInput;
    Light2D ownLight;
    Animator animator;
    Animator stickAnimator;
    bool canMove = true;
    public bool CanMove
    {
        get{return canMove;}
        set {canMove = value;}
    }
    bool canWin = false;
    public bool CanWin
    {
        get{return canWin;}
    }

    // Get animation reference
    void Awake()
    {
        ownLight = GetComponentInChildren<Light2D>();
        rb2D = GetComponent<Rigidbody2D>();
        detectionRadius = standardDetectionRadius;
        animator = GetComponent<Animator>();
        stickAnimator = gatheringStick.GetComponent<Animator>();
    }
    void OnEnable()
    {
        Score.OnLootCompleted += CanWinGame;
    }
    void OnDisable()
    {
        Score.OnLootCompleted -= CanWinGame;
    }

    void CanWinGame()
    {
        canWin = true;
    }

    void Update()
    {
        if (!canMove) return;
       
        CharacterInput();

        
        
    }

    void CharacterInput()
    {
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveY = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveY = -1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
            moveX = 1f;

        movement = new Vector2(moveX,moveY).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            detectionRadius = stealthDetectionRadius;
            movementSpeed = stealthMovementSpeed;
            ownLight.pointLightOuterRadius = stealthDetectionRadius;
        }
        else
        {
            detectionRadius = standardDetectionRadius;
            movementSpeed = standardMovementSpeed;
            ownLight.pointLightOuterRadius = standardDetectionRadius;
        }
        animator.SetFloat("MoveY", moveY);
        animator.SetFloat("MoveX", moveX);
            
        if (Input.GetKeyDown(KeyCode.K))  AudioManager.Instance.PlaySFX("Attack");
        if (Input.GetKey(KeyCode.K))
        {
            // Attack or harvest
            gatheringStick.gameObject.SetActive(true);
            if (moveX == 0 && moveY == 0)
            {
                stickAnimator.SetFloat("MoveY", -0.5f);
                return;
            }
            stickAnimator.SetFloat("MoveY", moveY);
            stickAnimator.SetFloat("MoveX", moveX);

        }
        else
        {
            gatheringStick.gameObject.SetActive(false);
        }
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
