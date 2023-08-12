using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
  
  [SerializeField] private float velocidadEnemy;
   [SerializeField] private Transform ControladorSuelo;
  [SerializeField] private float distancia;
  [SerializeField] private bool moviendoDerecha;
private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidadEnemy, rb.velocity.y);
        if(informacionSuelo == false)
        {
            Giro();
        }
    }

    private void Giro()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadEnemy *= -1;
    }



}
