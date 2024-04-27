using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVida : MonoBehaviour
{
    public int vida = 3;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo"))
        {
            sufrirDa�o();
            revisarVida();
        }
    }

    void revisarVida()
    {
        if (vida == 0)
        {
            //gameover
            animator.Play("morir");
        }
    }

    void sufrirDa�o()
    {
        animator.Play("da�o");
        vida--;
    }
}
