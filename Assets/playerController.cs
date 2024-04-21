using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velMovimiento = 5f;
    public int tipoMovimiento;
    public int contadorMonedas = 0;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey("a"))
    //    {
    //        rb2D.AddForce(new Vector2(-1000f * Time.deltaTime, 0));
    //        gameObject.GetComponent<Animator>().SetBool("moving", true);
    //        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    //    }
    //    if (Input.GetKey("d"))
    //    {
    //        rb2D.AddForce(new Vector2(1000f * Time.deltaTime, 0));
    //        gameObject.GetComponent<Animator>().SetBool("moving", true);
    //        gameObject.GetComponent<SpriteRenderer>().flipX = false;

    //    }
    //    if (!Input.GetKey("a") && Input.GetKey("d"))
    //    {

    //        gameObject.GetComponent<Animator>().SetBool("moving", false);
    //    }
    //    if (Input.GetKey("up"))
    //    {

    //    }
    //}

    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector2(movHorizontal, movVertical);

        if (tipoMovimiento == 1)
        {
            transform.Translate(movimiento * velMovimiento * Time.deltaTime);
        }else if (tipoMovimiento == 2)
        {
            rb2D.velocity = movimiento * velMovimiento;
        }
        else
        {
            rb2D.AddForce(movimiento * velMovimiento);

            if (Mathf.Abs(movHorizontal) > 0)
            {
                gameObject.GetComponent<Animator>().SetBool("moving", true);
            }
            else if (Mathf.Abs(movHorizontal) < 0)
            {
                gameObject.GetComponent<Animator>().SetBool("moving",true);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("moneda"))
        {
            print("+1");
            contadorMonedas++;
            
        }
    }
}
