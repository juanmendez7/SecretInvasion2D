using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    private float LastShoot;
    public GameObject BulletPrefab;
    public float VelocidadMovimiento;
    private Animator Animator;
public float FuerzaSalto;
 private Rigidbody2D rb;
 private float Horizontal;
 private bool Suelo;
private bool jumping = false;
 void Start()
 {
    rb = GetComponent<Rigidbody2D>();
    Animator = GetComponent<Animator>();

 }

 void Update()
 {
    Horizontal = Input.GetAxisRaw("Horizontal");

    if(Horizontal < 0.0f) transform.localScale = new Vector3(-0.3462f, 0.3462f, 0.3462f);
    else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.3462f, 0.3462f, 0.3462f);

    
    Animator.SetBool("running", Horizontal != 0.0f);

    Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);

    if(Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
    {
        Suelo = true;
    } else Suelo = false;

    if(Input.GetKeyDown(KeyCode.Space) && Suelo)
    {
        Jump();
        jumping = true;
        AudioManager.instance.PlayAudio(AudioManager.instance.Salto);
    }

    Animator.SetBool("jumping", jumping);

    if(Suelo)
    {
        jumping = false;
    }

    if(Input.GetKeyDown(KeyCode.X) && Time.time > LastShoot + 0.25f)
    {
        Shoot();
        AudioManager.instance.PlayAudio(AudioManager.instance.disparo);
        LastShoot = Time.time;
    }
 }

private void Shoot()
{
    Vector3 direction;
    if(transform.localScale.x == 0.3462f) direction = Vector2.right;
    else direction = Vector2.left;
    GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
    bullet.GetComponent<BulletScript>().SetDirection(direction);
}


 private void Jump()
 {
    rb.AddForce(Vector2.up * FuerzaSalto);
    jumping = true;
 }

private void FixedUpdate()
{
    rb.velocity = new Vector2(Horizontal * VelocidadMovimiento, rb.velocity.y);
}

}
