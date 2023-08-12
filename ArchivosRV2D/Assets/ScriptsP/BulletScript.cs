using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    public float VelocidadBala;
    private Rigidbody2D rbBullet;
    private Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbBullet.velocity = Direction * VelocidadBala;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
