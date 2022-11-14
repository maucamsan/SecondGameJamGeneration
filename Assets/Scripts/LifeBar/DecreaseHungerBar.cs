using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DecreaseHungerBar : MonoBehaviour
{
    [SerializeField] float increaseHunger = 2.0f;
    [SerializeField] float intervalToReduce = 2.0f;
    Hunger hunger;
    bool canDecreaseHunger = true;
    public bool CanDecreaseHunger
    {
        get{return canDecreaseHunger;}
        set{canDecreaseHunger = value;}
    }
    float hungerInterval;

    void OnEnable()
    {
        canDecreaseHunger = true;
        GameManager.OnLevelReset += StopDecreasing;
    }
    void OnDisable()
    {
        StopCoroutine(Starve());
        GameManager.OnLevelReset -= StopDecreasing;

    }
    void StopDecreasing()
    {
        StopCoroutine(Starve());
        canDecreaseHunger = false;
    }
    void Start()
    {
        hunger = GetComponent<Hunger>();
        hunger.Curar(101);
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
