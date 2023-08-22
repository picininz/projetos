using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    Vector2 limits = new Vector2(18.20f, 11.7f);


    void Awake()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        if(Mathf.Abs(x) > Mathf.Abs(y))
        {
            x = x * limits.x;
            y = Mathf.Sign(y) * limits.y;
        }
        else
        {
            y = y * limits.y;
            x = Mathf.Sign(x) * limits.x;
        }
        transform.position += new Vector3(x, y, 0);
    }

    
    
}
