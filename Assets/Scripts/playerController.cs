using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    public LayerMask capaSuelo;

    private int estado = 0;
    private Rigidbody2D rb2D;
    private BoxCollider2D boxCollider;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        moverPersonaje();
        realizarSalto();
    }

    void moverPersonaje()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(movHorizontal * velocidad, rb2D.velocity.y);

        //animator.SetFloat("Horizontal", Mathf.Abs(movHorizontal));

        if (movHorizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetInteger("estado",1);
        }
        else if (movHorizontal < 0)
        {
            animator.SetInteger("estado", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.SetInteger("estado", 0);
        }
    }

    void realizarSalto()
    {
        //float movVertical = Input.GetAxis("Vertical");
        //animator.SetFloat("Vertical", Mathf.Abs(movVertical));


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && tocandoSuelo())
        {
            rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetBool("enElSuelo", false);
            animator.SetBool("saltando",true);
        }
        if (rb2D.velocity.y > 0.1)
        {
            animator.SetInteger("estado", 2);
        }
        if (rb2D.velocity.y < -0.1)
        {
            animator.SetInteger("estado", 3);
        }
    }

    bool tocandoSuelo()
    {
        RaycastHit2D rh = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.4f, capaSuelo);
        animator.SetBool("enElSuelo", true);
        animator.SetBool("saltando", false);
        //animator.SetInteger("estado", 0);
        return rh.collider != null;
    }

}
