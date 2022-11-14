using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootObject;
public class Hunger : MonoBehaviour
{
    
    [SerializeField] public float vida; 
    [SerializeField] private float maximoVida;
    [SerializeField] private Bar bar;
    
    void OnEnable()
    {
        // vida = 100;
        GameManager.OnLevelReset += ResetLife;
        LootObject.Destroy.OnFoodGrabbed += Curar;
        Enemy2D.OnDamageInflicted += TomaeDaño;
    }
    void OnDisable()
    {
        Enemy2D.OnDamageInflicted -= TomaeDaño;
        GameManager.OnLevelReset -= ResetLife;
        LootObject.Destroy.OnFoodGrabbed -= Curar;
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
