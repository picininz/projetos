using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int pontos;
    public Text txtPontos;
    public int vidas;
    public Text txtVidas;


    void Start()
    {
        instance = this;

    }

  
    void Update()
    {
        
    }

    public void AddPontos()
    {
        pontos++;
        txtPontos.text = "Pontos: " + pontos;
        if (pontos >= 10)
        {
            SceneManager.LoadScene("cenavitoria");
        }

    }

    public void PlayerHit()
    {
        vidas++;
        txtVidas.text = "Dano: " + vidas;
        if(vidas >= 5)
        {
            GameController.instance.GameOver();
        }

    }
    public void GameOver()
    {
        SceneManager.LoadScene("cenaderrota");
    }

}
