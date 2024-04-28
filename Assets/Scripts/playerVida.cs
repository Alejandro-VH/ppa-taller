using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVida : MonoBehaviour
{
    [SerializeField] private int vida = 3;
    [SerializeField] private float empuje = 5f;
    [SerializeField] private GameObject gameover;
    private Animator animator;
    private Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo"))
        {
            sufrirDaño();
            revisarVida();
            empujar(collision);
        }
        if (collision.CompareTag("agua"))
        {
            morir();
        }
    }

    private void empujar(Collider2D collision)
    {
        Rigidbody2D rbEnemigo = collision.GetComponent<Rigidbody2D>();
        Vector2 direccionDeEmpuje;

        if (rbEnemigo != null && rbEnemigo.velocity != Vector2.zero)
        {
            // Usar la dirección de la velocidad del enemigo si se está moviendo
            direccionDeEmpuje = rbEnemigo.velocity.normalized;
        }
        else
        {
            // Empuje en una dirección aleatoria sin usar Random
            float randomAngle = Time.time * 10; // Utiliza el tiempo como semilla para generar un ángulo "aleatorio"
            direccionDeEmpuje = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        }

        rb2D.AddForce(direccionDeEmpuje * empuje, ForceMode2D.Impulse);
    }

    void revisarVida()
    {
        if (vida == 0)
        {
            morir();
        }
    }

    void sufrirDaño()
    {
        animator.Play("daño");
        vida--;
    }

    void morir()
    {
        animator.Play("morir");
        this.gameObject.GetComponent<playerController>().enabled = false;
        gameover.SetActive(true);
    }
}
