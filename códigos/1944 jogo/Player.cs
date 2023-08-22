using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Gun gun;
   


    void Start()
    {
        
    }

   
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, -h * 60);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            gun.tipoTiro++;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameController.instance.PlayerHit();
            Destroy(other.gameObject);
        }

    }
}
