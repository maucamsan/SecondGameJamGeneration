using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Slider slider;
    
    private void Start()
    {
        slider = GetComponent <Slider>();
    }

    public void  CambiarVidaMaxima (float vidaMaxima){
        slider.maxValue = vidaMaxima;
    }

    public void CmabiarVidaActual (float CantidadVida){
        slider.value = CantidadVida;

    }

    public void InicializarBarraVida (float cantidadVida){
        CambiarVidaMaxima(cantidadVida);
        CmabiarVidaActual(cantidadVida);
    }
}
