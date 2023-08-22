using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;


    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

   
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
