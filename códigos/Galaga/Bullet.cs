using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    
    
  
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
    }
}
