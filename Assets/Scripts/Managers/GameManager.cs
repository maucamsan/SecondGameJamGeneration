using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public enum GameState
{
    Pregame, MainMenu, GamePlay, Paused, Victory, GameOver, Restart
}
public class GameManager : Singleton<GameManager>
{
    // Load Main Scene
    // Load gameplay scene
    // Restart game
    // Pause game
    // Exit to main    
    
    CanvasManager canvasManager;
    GameState currentGameState = GameState.Pregame;
    void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        UpdateState(currentGameState);
        ButtonController.OnGameStateChanged += UpdateState;
    }
    
    void OnDisable()
    {
        ButtonController.OnGameStateChanged -= UpdateState;
    }
    void UpdateState(GameState state)
    {
        switch(currentGameState)
        {
            case GameState.Pregame:
                // LoadLevel("Boot");
                
                try
                {
                    UnloadLevel("Main");
                    //LoadLevel("Boot");
                }
                catch (ArgumentException)
                {
                    break;
                }
                break;
            case GameState.MainMenu:
                Debug.Log("My current state is main menu");
                // Don't let player move
                // Set music accorgingly
                //canvasManager.SwitchCanvas(CanvasType.MainMenu);
                //
                StartGame();
                UnPauseGame();
                InventoryReset();
                break;
            case GameState.GamePlay:
                //canvasManager.SwitchCanvas(CanvasType.GameUI);
                UnPauseGame();
                // Set gameplay music
                // Allow player and game mechanics
                break;
            case GameState.Paused:
                // Stop time
                //canvasManager.SwitchCanvas(CanvasType.PauseScreen);
                PauseGame();
                break;
            case GameState.Victory:
                //canvasManager.SwitchCanvas(CanvasType.VictoryScreen);
                InventoryReset();
                PauseGame();
                // send to main menu
                break;
            case GameState.GameOver:
                //canvasManager.SwitchCanvas(CanvasType.EndScreen);
                InventoryReset();
                PauseGame();
                // Let restart
                // Let send to main menu
                break;
            case GameState.Restart:
                UnloadLevel("Main");
                
                currentGameState = GameState.Pregame;
                break;


        }
    }

    public GameState CurrentGamestate
    {
        get {return currentGameState;}
        set{currentGameState = value;
            UpdateState(currentGameState);}
    }
    public void StartGame()
    {
        LoadLevel("Main");
    }

    void InventoryReset()
    {
        // Reset inventory
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level: " + levelName);
            return;
        }
        ao.completed += OnLoadOperationComplete;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level: " + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("operation completed");
    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("unloaded completed");
    }
}
