using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VoltaController : MonoBehaviour
{
   
    public int score;
    public Text txtScore;
    private float timeLevel;
    public Text timeLevel_txt;

    void Start()
    {

    }

    void Update()
    {
        timeLevel = timeLevel + Time.deltaTime;
        timeLevel_txt.text = timeLevel.ToString("TEMPO: 0.0");

    }

    public string scene;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score = score + 1;
            txtScore.text = "VOLTAS: " + score;
            if (score > 3)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
