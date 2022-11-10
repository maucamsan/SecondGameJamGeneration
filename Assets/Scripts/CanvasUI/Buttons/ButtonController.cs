using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
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
            case ButtonType.StartGame:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Credits:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Pause:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Restart:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Resume:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.Options:
                // Load Scene, call game manager
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            default:
                break;
        }
    }
}
