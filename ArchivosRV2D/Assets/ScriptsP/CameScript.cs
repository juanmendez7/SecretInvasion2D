using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameScript : MonoBehaviour
{
   
   public GameObject Nick;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Nick.transform.position.x;
        transform.position = position;
    }
}
