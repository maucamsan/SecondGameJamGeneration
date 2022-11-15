using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayerToParent : MonoBehaviour
{
    private string layer;
    private string sortingLayer;
    void OnEnable()
    {
        gameObject.layer = LayerMask.NameToLayer(LayerMask.LayerToName(GetComponentInParent<Transform>().gameObject.layer));
        Debug.Log(LayerMask.NameToLayer(LayerMask.LayerToName(GetComponentInParent<Transform>().gameObject.layer)));
        SpriteRenderer spriteRend =  GetComponent<SpriteRenderer>();
        spriteRend.sortingLayerName = GetComponentInParent<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName;

    }
    
}
