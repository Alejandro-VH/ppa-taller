using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoScript : MonoBehaviour
{
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadRotacion = 1000;

    private bool alPuntoB = true;

    void Update()
    {
        transform.Rotate(0f, 0f, velocidadRotacion * Time.deltaTime);

        Vector2 objetivoActual;
        if (alPuntoB)
        {
            objetivoActual = puntoB.position;
        }
        else
        {
            objetivoActual = puntoA.position;
            
        }

        transform.position = Vector2.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivoActual) < 0.001f)
        {
            alPuntoB = !alPuntoB; 
        }
    }
}
