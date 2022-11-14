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
     GameManager gm;
     CanvasManager canvasManager;
     bool exit = false;
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
    void StopEverything()
    {
        canDecreaseHunger = false;
        exit = true;
    }
    void Start()
    {
        hunger = GetComponent<Hunger>();
        hunger.Curar(101);
        hungerInterval = intervalToReduce;
        gm = GameManager.GetInstance();
        canvasManager = CanvasManager.GetInstance();
    }

    void Update()
    {
        if (hunger.vida <= 0) 
        {
            StopAllCoroutines();
            GameManager.GetInstance().CurrentGamestate = GameState.GameOver;
            canvasManager.SwitchCanvas(CanvasType.EndScreen);
        }
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
