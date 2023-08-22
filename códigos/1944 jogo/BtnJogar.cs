using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnJogar : MonoBehaviour
{
    public string cena;

    void Start()
    {
        
    }

    
    public void BtnCkick()
    {
        SceneManager.LoadScene(cena);
    }
}
