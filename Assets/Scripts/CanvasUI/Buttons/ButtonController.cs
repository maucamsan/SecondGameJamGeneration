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
                GameManager.GetInstance().StartGame();
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.MainMenu:
                Debug.Log("main menu activate");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.StartGame:
                GameManager.GetInstance().CurrentGamestate = GameState.GamePlay;
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Credits:
                canvasManager.SwitchCanvas(CanvasType.Credits);
                break;
            case ButtonType.Pause:
                GameManager.GetInstance().CurrentGamestate = GameState.Paused;
                canvasManager.SwitchCanvas(CanvasType.PauseScreen);
                break;
            case ButtonType.Restart:
                GameManager.GetInstance().CurrentGamestate = GameState.Pregame;
                canvasManager.SwitchCanvas(CanvasType.Pregame);
                break;
            case ButtonType.Resume:
                GameManager.GetInstance().CurrentGamestate = GameState.GamePlay;
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Options:
                canvasManager.SwitchCanvas(CanvasType.Options);
                break;
            default:
                break;
        }
    }
}
