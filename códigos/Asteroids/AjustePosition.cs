using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustePosition : MonoBehaviour
{
    Vector3 max = new Vector3(18.20f, 11.7f, 0);
    Vector3 min = new Vector3(-18.20f, -9.25f, 0);




    void Start()
    {
        
    }

   
    void Update()
    {
        if (transform.position.x > max.x)
        {
            Vector3 tmp = transform.position;
            tmp.x = min.x;
            transform.position = tmp;
        }
        if (transform.position.x < min.x)
        {
            Vector3 tmp = transform.position;
            tmp.x = max.x;
            transform.position = tmp;
        }
        if (transform.position.y < min.y)
        {
            Vector3 tmp = transform.position;
            tmp.y = max.y;
            transform.position = tmp;
        }
        if (transform.position.y > max.y)
        {
            Vector3 tmp = transform.position;
            tmp.y = min.y;
            transform.position = tmp;
        }
    }
}
