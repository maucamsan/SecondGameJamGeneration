using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHungerBar : MonoBehaviour
{
    [SerializeField] float increaseHunger = 2.0f;
    [SerializeField] float intervalToReduce = 2.0f;
    Hunger hunger;
    bool canDecreaseHunger = true;
    float hungerInterval;

    void Start()
    {
        hunger = GetComponent<Hunger>();
        hungerInterval = intervalToReduce;
    }

    void Update()
    {
        if (canDecreaseHunger)
        {
            canDecreaseHunger = false;
            hunger.TomaeDaño(increaseHunger);
            StartCoroutine(Starve());
        }
    }

    IEnumerator Starve()
    {

        while(hungerInterval >= 0)
        {
            hungerInterval -= Time.deltaTime;
            yield return null;
        }
        canDecreaseHunger = true;
        hungerInterval = intervalToReduce;
        yield return null;
    }
}
