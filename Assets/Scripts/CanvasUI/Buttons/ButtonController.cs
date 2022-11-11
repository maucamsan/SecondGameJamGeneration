using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public enum ButtonType
{
    Pregame,
    MainMenu,
    StartGame,
    Restart,
    Credits,
    Pause,
    Resume,
    Options
}

[RequireComponent(typeof(Button))] 
public class ButtonController : MonoBehaviour
{
    public static Action<GameState> OnGameStateChanged;
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;

    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClick);
        canvasManager = CanvasManager.GetInstance();
    }

    private void OnButtonClick()
    {
        switch(buttonType)
        {
            case ButtonType.Pregame:
                Debug.Log("What is going on"); 
                GameManager.GetInstance().StartGame();
                // OnGameStateChanged?.Invoke(GameState.Pregame);
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.MainMenu:
                GameManager.GetInstance().CurrentGamestate = GameState.MainMenu;
                Debug.Log("main menu activate");
                // OnGameStateChanged?.Invoke(GameState.MainMenu);
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.StartGame:
                // Load Scene, call game manager
                GameManager.GetInstance().CurrentGamestate = GameState.GamePlay;
                // OnGameStateChanged?.Invoke(GameState.GamePlay);
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Credits:
                // Load Scene, call game manager
                GameManager.GetInstance().CurrentGamestate = GameState.MainMenu;
                //OnGameStateChanged?.Invoke(GameState.MainMenu);
                canvasManager.SwitchCanvas(CanvasType.Credits);
                break;
            case ButtonType.Pause:
                // Load Scene, call game manager
                GameManager.GetInstance().CurrentGamestate = GameState.Paused;
                // OnGameStateChanged?.Invoke(GameState.Paused);
                canvasManager.SwitchCanvas(CanvasType.PauseScreen);
                break;
            case ButtonType.Restart:
                // Restart Game, call game manager
                GameManager.GetInstance().CurrentGamestate = GameState.Pregame;
                // OnGameStateChanged?.Invoke(GameState.Restart);
                canvasManager.SwitchCanvas(CanvasType.Pregame);
                break;
            case ButtonType.Resume:
                // Set time to 1
                GameManager.GetInstance().CurrentGamestate = GameState.GamePlay;
                // OnGameStateChanged?.Invoke(GameState.GamePlay);
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Options:
                // Load Scene, call game manager
                GameManager.GetInstance().CurrentGamestate = GameState.Paused;
                //OnGameStateChanged?.Invoke(GameState.Paused);
                canvasManager.SwitchCanvas(CanvasType.Options);
                break;
            default:
                break;
        }
    }
}
