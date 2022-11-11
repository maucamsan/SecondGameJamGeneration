using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    Slider hungerMeter;
    public float hunger = 100;
    Color fullColor;
    Color hungryColor;
    Color reference;
    [SerializeField] Image imageFiller;
    void Start()
    {
        hungerMeter = GetComponent<Slider>();
        reference = GetComponentInChildren<Image>().color;
        fullColor = reference;
        hungryColor = Color.red;
    }
    void Update()
    {
        HandleColorBar();
    }
    void HandleColorBar()
    {
        
        float t = Mathf.InverseLerp(20f, 50f, hungerMeter.value);
        imageFiller.color = Color.Lerp(hungryColor, fullColor, t);
    }
}
