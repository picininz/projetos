using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Vector3 rotate;
    Vector3 dir;
    public GameObject explosion;


    void Start()
    {
        rotate = new Vector3(Random.Range(-80, 80), Random.Range(-80, 80), Random.Range(-80, 80));
        dir = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
    }

    
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
        transform.position += dir * Time.deltaTime;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            GameController.instance.AddPontos(5);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);

            
        }
    }
}
