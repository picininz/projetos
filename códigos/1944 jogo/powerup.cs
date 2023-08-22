using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public float speed;


    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
