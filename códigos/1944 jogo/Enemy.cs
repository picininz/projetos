using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float amplitute;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 dir = new Vector3(Mathf.Sin(transform.position.z) * amplitute, 0, -1);
        transform.position += dir * speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameController.instance.AddPontos();
        }
    }
}
