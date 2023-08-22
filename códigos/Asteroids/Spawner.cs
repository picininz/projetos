using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float time;
    public GameObject obj;

    void Start()
    {
        Invoke("Spawn", time);
    }

  
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(obj, transform.position, transform.rotation);
        Invoke("Spawn", time);
    }
}
