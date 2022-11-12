using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    
    [SerializeField] private float vida; 
    [SerializeField] private float maximoVida;
    [SerializeField] private Bar bar;
    

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
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
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



}
