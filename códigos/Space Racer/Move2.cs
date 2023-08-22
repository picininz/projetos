using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public Transform[] p;
    public float speed;
    public int index = 0;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Vector3 dir = p[index].position - transform.position;
        transform.position += dir.normalized * speed * Time.fixedDeltaTime;
        if (dir.magnitude < 1f)
        {
            index = (index + 1) % p.Length;
        }
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
