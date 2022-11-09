using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class DetectionBehavior : MonoBehaviour
{
    [SerializeField] Controller2D  playerTransform;
    public float detectRadius;
    float distanceToPlayer;

    void Update()
    {
        distanceToPlayer = ((Vector2)transform.position - (Vector2) playerTransform.transform.position).magnitude;
        if (distanceToPlayer - detectRadius <= playerTransform.DetectionRadius)
        {
            Debug.Log("ATTACK!");
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
#endif
}
