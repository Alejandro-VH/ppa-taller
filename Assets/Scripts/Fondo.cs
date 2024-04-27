using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D rb;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = (rb.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
