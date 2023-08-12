using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{

    public GameObject proyectil;

    public float TiempoDisparo;
    public float ShootCooldown;
    public bool frecuenciaDisparo;
    public bool vigilante;
    // Start is called before the first frame update
    void Start()
    {
        ShootCooldown = TiempoDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        if(frecuenciaDisparo)
        {
            ShootCooldown -= Time.deltaTime;
        }
        
        if(ShootCooldown < 0)
        {
            Shoot2();
        }

        if(vigilante)
        {
            
        }
    }



    public void Shoot2()
    {
        GameObject bala1 = Instantiate(proyectil, transform.position, Quaternion.identity);
            if(transform.localScale.x < 0)
            {
                bala1.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f), ForceMode2D.Force);
            } else{
                bala1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f), ForceMode2D.Force);
            }

            

            ShootCooldown = TiempoDisparo;
    }
}
