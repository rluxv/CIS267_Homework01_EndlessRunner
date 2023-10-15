using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lifebar1;

    public GameObject lifebar2;

    public GameObject lifebar3;

    public GameObject lifebar4;
    public GameObject Canvas;
    public bool isGameOver;

    private int score;
    public TMP_Text scoreTMP;

    //Spike Shield
    public bool spikeShieldActive;
    public int spikeShieldHits;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        evalGameState();
        score = 0;
        spikeShieldActive = false;
        spikeShieldHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeHealthBar(int num)
    {
        if (num == 1)
        {
            Destroy(lifebar1);
        }
        if (num == 2)
        {
            Destroy(lifebar2);
        }
        if (num == 3)
        {
            Destroy(lifebar3);
        }
        if (num == 4)
        {
            Destroy(lifebar4);
        }
    }

    public void gameOver()
    {
        Canvas.GetComponent<GameOverMenu>().showGameOverMenu();
        isGameOver = true;
        evalGameState();
    }

    public void restartGame()
    {
        isGameOver = false;
        evalGameState();
        SceneManager.LoadScene("RunnerScene");
    }

    public void evalGameState()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void addScore(int sc)
    {
        score += sc;
        scoreTMP.text = "Score: " + score;
    }
}
