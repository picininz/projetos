using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnJogar : MonoBehaviour
{
    public AudioSource som;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string scene;
    public void BtnClick()
    {
        SceneManager.LoadScene(scene);
        som.Play();
    }
}
