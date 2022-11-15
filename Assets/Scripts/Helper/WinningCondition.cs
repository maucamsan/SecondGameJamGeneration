using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    CanvasManager canvasManager;
    void Start()
    {
        canvasManager = CanvasManager.GetInstance();
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Controller2D>().CanWin)
        {
            // win the game
            GameManager.GetInstance().CurrentGamestate = GameState.Victory;
            canvasManager.SwitchCanvas(CanvasType.VictoryScreen);
        }
    }
}
