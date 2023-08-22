using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    public string nome;


    public void OnScene()
    {
        SceneManager.LoadScene(nome);
    }
}
