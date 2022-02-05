using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterScore : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    [SerializeField] private string scoreTag;
    private PipeSpawner pipeSpawner;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore.ToString();
        pipeSpawner = GameObject.FindObjectOfType<PipeSpawner>();
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == scoreTag)
        {
           Score();
        }
    }

    public void Score()
    {
        score++;
        scoreText.text = "Score: " + score;
        if(pipeSpawner != null)
        {
            pipeSpawner.CanSpawn();
        }
    }
    
    public void SaveHighScore()
    {
        if(highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore",highScore);
        }
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
