using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject PowerUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {

            Destroy(other.gameObject);
            GameController.instance.AddScore();
            Instantiate(PowerUp, transform.position, transform.rotation);
            Destroy(gameObject);
        }   
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }

      





    }

}
