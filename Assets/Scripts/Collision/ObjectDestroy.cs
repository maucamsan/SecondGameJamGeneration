using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject obj;
    public int lifeObject;
    private void Update()
    {
        if (lifeObject < 0)
        {
            Instantiate(obj);
            Destroy(gameObject);
        }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tool"))
        {
            lifeObject--;

        }
    }
}