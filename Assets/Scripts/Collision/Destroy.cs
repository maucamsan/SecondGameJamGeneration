using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject eeffect;
    [SerializeField] private int cantidaPuntos;
    TypeOfLoot loot;
    void Start()
    {
        loot = GetComponent<TypeOfLootSelector>().loot;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("ladder"))
        {
            Destroy(other.gameObject);
            Score.SumarPuntos(cantidaPuntos, loot);
        }
    }
}
