using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class recolectorMonedas : MonoBehaviour
{
    public int objetivoMonedas = 1; // temporal
    private int contadorMonedas = 0;
    public TextMeshProUGUI monedas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("moneda"))
        {
            contadorMonedas++;
            monedas.text = contadorMonedas + "";
        }

        if (collision.CompareTag("cofre"))
        {
            if (contadorMonedas == objetivoMonedas)
            {
                print("Nivel completado");
                //habrai que hacer la animacion de abrir cofre aca, o si quieres haces otro script o un "script manager que le diga al cofre que se abara"
            }
            else
            {
                print("faltan monedas");
            }
        }
    }
}
