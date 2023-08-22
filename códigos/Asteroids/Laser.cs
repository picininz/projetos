using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed;



    void Start()
    {
        Destroy(this.gameObject, 2.0f);
    }

    
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

    }
}
