using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController2 : MonoBehaviour
{
    private float moveInput, turnInput;
    public float fwdSpeed, revSpeed, turnSpeed;
    public Rigidbody sphereRB;
    public GameObject drift;

  
    



    void Start()
    {
        sphereRB.transform.parent = null;
        
       
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("A"))
        {
            Instantiate(drift, transform.position, transform.rotation);
        }

     
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

       
        transform.position = sphereRB.transform.position;

        
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);

       

     
    }

    private void FixedUpdate()
    {
      
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);

       
    }

   
}
