using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject gun1;
    public GameObject gun2;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = new Vector3(h, v, 0);
        rb.velocity = vel * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            GameController2.instance.PlayerHit();
            Destroy(other.gameObject);


        }

        if (other.gameObject.CompareTag("PowerUp"))
        {

            gun1.SetActive(false);
            gun2.SetActive(true);
            Destroy(other.gameObject);
        }








    }






}