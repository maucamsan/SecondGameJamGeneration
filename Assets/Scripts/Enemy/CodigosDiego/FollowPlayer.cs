using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : StateMachineBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeFollow;
    
    [SerializeField]
    private float timeBase;
    public Transform player;
    private Enemy2D enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeFollow = timeBase; 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = animator.gameObject.GetComponent<Enemy2D>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);
        enemy.Girar(player.position);
        timeFollow -= Time.deltaTime;
        if (timeFollow <= 0)
        {
            animator.SetTrigger("Volver");


        }
        if (enemy.distanceToPlayer - enemy.detectRadius <= enemy.playerRef.DetectionRadius && enemy.timeAttack <=0)
        {
            animator.SetTrigger("Attack");

        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
