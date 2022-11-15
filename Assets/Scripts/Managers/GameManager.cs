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
    public static Action<int, FadeAnim> OnFirstMovement;
    public static Action<int, FadeAnim> OnFirstShift;
    public static Action OnLevelReset;
    public static Action OnGameOver;
    CanvasManager canvasManager;
    GameState currentGameState = GameState.Pregame;
    bool firstMovement = true;
    bool firstShift = true;
    void Start()
    {
        UpdateState(currentGameState);
        AudioManager.Instance.PlayMusic("BackgroundMusic");
    }
    IEnumerator FirstMove()
    {
        while(true)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                break;
            }
            yield return null;
        }
        firstMovement = false;
        OnFirstMovement?.Invoke(0, FadeAnim.FadeOut);
        yield return new WaitForSeconds(1f);
        OnFirstMovement?.Invoke(1, FadeAnim.FadeIn);
        StartCoroutine(FirstTutorialShift());
    }
    
    IEnumerator FirstTutorialShift()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                break;
            }
            yield return null;
        }
        firstShift = false;
        OnFirstShift?.Invoke(1, FadeAnim.FadeOut);
        StartCoroutine(SecondTutorialShift());
    }
    IEnumerator SecondTutorialShift()
    {
        while(true)
        {
            if (Input.GetKey(KeyCode.K))
            {
                break;
            }
            yield return null;
        }
        OnFirstMovement?.Invoke(2, FadeAnim.FadeOut);
    }
    void UpdateState(GameState state)
    {
        Controller2D controller = FindObjectOfType<Controller2D>();
        
        switch(currentGameState)
        {
            case GameState.Pregame:
                try
                {
                    UnloadLevel("Main");
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
                StartGame();
                UnPauseGame();
                ResetGame();
                

                break;
            case GameState.GamePlay:
                UnPauseGame();
                controller.CanMove = true;
                if (firstMovement)
                {
                    StartCoroutine(FirstMove());
                }
                // Set gameplay music
                // Allow player and game mechanics
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.Victory:
                //ResetGame();
                PauseGame();
                //canvasManager.SwitchCanvas(CanvasType.VictoryScreen);
                // send to main menu
                break;
            case GameState.GameOver:
                //canvasManager.SwitchCanvas(CanvasType.EndScreen);
                // Let restart
                // Let send to main menu
                //StopAllCoroutines();
                // UnloadLevel("Main");
                OnGameOver?.Invoke();
                Controller2D c = FindObjectOfType<Controller2D>();
                c.CanMove = false;
                
                break;
            case GameState.Restart:
                UnloadLevel("Main");
                
                break;


        }
    }

    public GameState CurrentGamestate
    {
        get {return currentGameState;}
        set
        {
            currentGameState = value;
            UpdateState(currentGameState);
        }
    }
    public void StartGame()
    {
        LoadLevel("Main");
    }

    void ResetGame()
    {
        // Reset inventory
        // Reset hunger bar
        // Place player in initial position
        // Reset lootables
        // Reset enemies
        OnLevelReset?.Invoke();
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
        Controller2D controller = FindObjectOfType<Controller2D>();
        controller.CanMove = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        ResetGame();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Boot"));
        firstMovement = true;
        firstShift = true;
        StopAllCoroutines();
        currentGameState = GameState.Pregame;
        Debug.Log("unloaded completed");
        // Notify life bar to replenish again
        // Reset loot values
    }
}
