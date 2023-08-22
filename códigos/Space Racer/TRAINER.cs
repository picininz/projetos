using UnityEngine;
using UnityEngine.UI;
public class NewCar: MonoBehaviour
{
    private float moveInput, turnInput;
    public float fwdSpeed, revSpeed, turnSpeed;
    public Rigidbody sphereRB;
    float time;
    

    float[] speeds = { 1.0f, 1.3f, 1.5f, 1.6f };
    int testMarcha = 0;
  


    void Start()
    {
        sphereRB.transform.parent = null;
    }
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");

        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        
        transform.Rotate(0, newRotation, 0, Space.World);
     
    }
    private void FixedUpdate()
    {
       if (moveInput > 0.1f)
       {
            time += Time.fixedDeltaTime;
            
       }
       else
       {
            time -= Time.fixedDeltaTime;
       }
        if (time > 3) time = 3;
        if (time < 0) time = 0;
        testMarcha = (int)time;
     
        sphereRB.AddForce(transform.forward * speeds[testMarcha] * moveInput, ForceMode.Acceleration);
    }

   
}
