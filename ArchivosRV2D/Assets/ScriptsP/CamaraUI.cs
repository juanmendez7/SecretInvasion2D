using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraUI : MonoBehaviour
{
    public Transform jugador;
    public float posX;
    public float posY;
    public float posZ;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(jugador.position.x + posX, jugador.position.y + posY, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(jugador.position.x + posX, jugador.position.y + posY, posZ);
    }
}
