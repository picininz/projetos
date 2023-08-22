using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public int pontos;
    public Text Txtpontos;
    private float timeLevel;
    public Text timeLevel_txt;
    public string scene;
    public int vidas;
    public Text txtVidas;


    void Start()
    {

    }

    void Update()
    {
        timeLevel = timeLevel + Time.deltaTime;
        timeLevel_txt.text = timeLevel.ToString("TIMER: 0.00");

    }


    void Awake()
    {
        
            instance = this;
        
       
    }
    
    
    public void AddPontos(int p)
    {
        pontos += p;
        if (Txtpontos != null)
        {
            Txtpontos.text = "Score: " + pontos;
            if (pontos > 100)
            {
                SceneManager.LoadScene(scene);
            }
        }
        

    }
    public void PlayerHit()
    {
        vidas++;
        txtVidas.text = "LIFES: " + vidas;
        if (vidas > 3)
        {
            GameController.instance.GameOver();
        }

    }
    public void GameOver()
    {
        SceneManager.LoadScene("cenaderrota");
    }
}
