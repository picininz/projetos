using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bala;
    public Transform mira;
    public KeyCode keyShoot;
    public int tipoTiro;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(keyShoot))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        for (int i = -tipoTiro; i <= tipoTiro; i++)
        {
            Vector3 p = new Vector3(tipoTiro * 0.25f, 0, 0);
            Instantiate(bala, mira.position + p, mira.rotation);

        }
    }
}
