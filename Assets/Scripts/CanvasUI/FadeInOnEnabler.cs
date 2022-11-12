using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnEnabler : MonoBehaviour
{
   void OnEnable()
   {
        CanvasManager.GetInstance().TryFadeIn();
   }
}
