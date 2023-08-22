using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour
{
    public static GameController2 instance;
    public int score;
    public int lives = 10;
    public Text txtScore;
    public Text txtLives;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore()
    {
        score = score + 20;
        txtScore.text = "SCORE: " + score;
        if (score >= 2000)
        {
            SceneManager.LoadScene("cenavitoria");
        }
    }


    public void PlayerHit()
    {
        lives--;
        txtLives.text = "Lives: " + lives;
        if (lives <= 0)
        {
            SceneManager.LoadScene("cenaderrota");
        }
    }


    public void GameOver()
    {
        SceneManager.LoadScene("cenaderrota");
    }
}
