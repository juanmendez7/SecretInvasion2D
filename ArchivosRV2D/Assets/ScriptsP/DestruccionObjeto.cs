using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionObjeto : MonoBehaviour
{

    public float SegundosDestruccion;
    // Start is called before the first frame update
    void Start()
    {
          Destroy(gameObject, SegundosDestruccion);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
