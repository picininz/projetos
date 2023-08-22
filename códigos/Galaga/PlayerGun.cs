using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public GameObject bullet;
    public KeyCode key;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
