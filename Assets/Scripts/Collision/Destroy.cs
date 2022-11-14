using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LootObject
{

    public class Destroy : MonoBehaviour
    {
        public static Action<float> OnFoodGrabbed;
        [SerializeField] private GameObject eeffect;
        [SerializeField] private int cantidaPuntos;
        TypeOfLoot loot;
        void Start()
        {
            loot = GetComponent<TypeOfLootSelector>().loot;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.gameObject.CompareTag("Player"))
            {
                if (loot == TypeOfLoot.Food)
                {
                    OnFoodGrabbed?.Invoke(20.0f);
                }
                Score.SumarPuntos(cantidaPuntos, loot);
                Debug.Log(cantidaPuntos);
                Destroy(gameObject);

            }
        }
    }

}