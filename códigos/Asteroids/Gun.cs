using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject laser;
    public Transform gun;
    public AudioSource laserAudio;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        laserAudio.Play();
        Instantiate(laser, gun.position, gun.rotation);
    }
}
