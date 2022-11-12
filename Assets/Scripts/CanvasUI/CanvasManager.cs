using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CanvasType
{
    Pregame,
    MainMenu,
    GameUI,
    EndScreen,
    VictoryScreen, 
    Credits, 
    PauseScreen,
    Options
}
public enum FadeAnim
{
    FadeOut, FadeIn
}

public class CanvasManager : Singleton<CanvasManager>
{
    private List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    [SerializeField] GameObject[] tutorial = new GameObject[2];
    Animator animator;

    protected override void Awake()
    {
        //base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.Pregame);
        GameManager.OnFirstMovement += Fade;
        GameManager.OnFirstShift += Fade;
    }
    void OnDisable()
    {
        GameManager.OnFirstMovement -= Fade;
        GameManager.OnFirstShift -= Fade;
    }
    public void SwitchCanvas(CanvasType type)
    {
        if (lastActiveCanvas != null)
            lastActiveCanvas.gameObject.SetActive(false);
        
         CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == type);

        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
            Debug.LogWarning("The main menu canvas was not found!");
    }

    public void TryFadeOut()
    {
        Fade(0, FadeAnim.FadeOut);
    }
    public void TryFadeIn()
    {
        Fade(1, FadeAnim.FadeIn);
    }
    private void Fade(int index, FadeAnim setAnim)
    {
        animator = tutorial[index].GetComponent<Animator>();
        switch (setAnim)
        {
            case FadeAnim.FadeIn:
                animator.SetTrigger("FadeIn");
                break;
            case FadeAnim.FadeOut:
                animator.SetTrigger("FadeOut");
                break;
            default:
                break;
        }
    }

    
}
