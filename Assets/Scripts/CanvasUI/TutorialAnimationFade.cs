using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialAnimationFade : MonoBehaviour
{
    Animator animator;
    Image imageReference;
    [SerializeField] GameObject switchTutorial;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void AlertObserversAfterFadeOut()
    {
        animator.ResetTrigger("FadeOut");
        try
        {
            switchTutorial.gameObject.SetActive(true);
            
        }
        catch (UnassignedReferenceException)
        {
            
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(false);
    }

    public void AlertObserversAfterFadeIn()
    {
        animator.ResetTrigger("FadeIn");
        //gameObject.SetActive(false);
    }
}
