using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnEnemy : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField]
    private Transform[] puntos;
    [SerializeField]
    private GameObject[] enemigos;
    [SerializeField]
    private float tiempoEnemigos;
    private float siguienteEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minX = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        siguienteEnemigo += Time.deltaTime;
        if (siguienteEnemigo >= tiempoEnemigos)
        {
            siguienteEnemigo = 0;
            CrearEnemigo();
        }
    }
    private void CrearEnemigo ()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}
