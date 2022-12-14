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
    Options,
    PregameCreds
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
                canvasManager.ResetLife();
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
                Debug.Log("Pause");
                canvasManager.SwitchCanvas(CanvasType.PauseScreen);
                GameManager.GetInstance().CurrentGamestate = GameState.Paused;
                break;
            case ButtonType.Restart:
                GameManager.GetInstance().CurrentGamestate = GameState.Restart;
                canvasManager.ResetLife();
                canvasManager.SwitchCanvas(CanvasType.Pregame);
                break;
            case ButtonType.Resume:
                GameManager.GetInstance().CurrentGamestate = GameState.GamePlay;
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Options:
                canvasManager.SwitchCanvas(CanvasType.Options);
                break;
            case ButtonType.PregameCreds:
                canvasManager.SwitchCanvas(CanvasType.Pregame);
                break;
            default:
                break;
        }
    }
}
