using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    
    [SerializeField] public float vida; 
    [SerializeField] private float maximoVida;
    [SerializeField] private Bar bar;
    
    void OnEnable()
    {
        // vida = 100;
        GameManager.OnLevelReset += ResetLife;
    }
    void OnDisable()
    {
        GameManager.OnLevelReset -= ResetLife;
    }
    private void Start()
    {
        vida = maximoVida;
        bar.InicializarBarraVida(vida);
    }
 
    [ContextMenu("TakeDamage")]
    public void TakeDamage()
    {
        TomaeDaño(5);
    }
    public void TomaeDaño(float daño)
    {
        vida -= daño;
        bar.CmabiarVidaActual(vida);
    }
    
    public void Curar (float curacion)
    {
        if ((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
    }

    void ResetLife()
    {
        vida = 100;
    }


}
