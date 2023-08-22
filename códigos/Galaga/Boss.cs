using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {

            Destroy(other.gameObject);
            GameController2.instance.AddScore();
            
            
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }







    }
}
