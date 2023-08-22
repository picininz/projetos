using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{

    public float speed;
    Vector3 dirVelocity;




    void Start()
    {
        
    }


    void Update()
    {
       
        
        Vector3 position = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(position);
        Vector3 dir = mousePos - transform.position;
        dir = dir.normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);


        if (Input.GetMouseButtonDown(1))
        {
            dirVelocity += new Vector3(dir.x, dir.y, 0);
        }
        transform.position += dirVelocity * speed * Time.deltaTime;


     


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            GameController.instance.PlayerHit();
            Destroy(other.gameObject);

        }
    }



}
