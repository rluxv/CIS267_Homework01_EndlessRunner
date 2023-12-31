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
    public GameObject lifebar5;
    public GameObject lifebar6;

    public GameObject Canvas;
    
    public bool isGameOver;

    [SerializeField] [Tooltip("Only use for debug purposes")] private int score;
    public TMP_Text scoreTMP;

    //Spike Shield
    public bool spikeShieldActive;
    public int spikeShieldHits;
    // Start is called before the first frame update
    private float timer;

    public bool clockCollectableActive;
    public float clockCollectableTimer;
    public bool playerCanMove;
    void Start()
    {
        isGameOver = false;
        evalGameState();
        spikeShieldActive = false;
        spikeShieldHits = 0;
        timer = 0;
        clockCollectableActive = false;
        clockCollectableTimer = 0;
        playerCanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTimer();
        clockCollectable();
    }

    public void clockCollectable()
    {
        if (clockCollectableActive)
        {
            clockCollectableTimer -= Time.deltaTime;
            if (clockCollectableTimer <= 0)
            {
                clockCollectableActive = false;
                Time.timeScale = 1f;
            }
        }
    }
    public void scoreTimer()
    {
        timer += Time.deltaTime;
        //every 30 seconds add 50 points
        if (timer >= 30)
        {
            addScore(50);
            timer = 0;
        }
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
            SpriteRenderer lbSpriteRender = lifebar1.GetComponent<SpriteRenderer>();
            lbSpriteRender.color = Color.red;
        }
        if (num == 3)
        {
            Destroy(lifebar3);
        }
        if (num == 4)
        {
            Destroy(lifebar4);
            SpriteRenderer lbSpriteRender = lifebar1.GetComponent<SpriteRenderer>();
            lbSpriteRender.color = Color.yellow;
            lbSpriteRender = lifebar2.GetComponent<SpriteRenderer>();
            lbSpriteRender.color = Color.yellow;
            lbSpriteRender = lifebar3.GetComponent<SpriteRenderer>();
            lbSpriteRender.color = Color.yellow;
        }
        if(num == 5)
        {
            Destroy(lifebar5);
        }
        if (num == 6)
        {
            Destroy(lifebar6);
        }
    }

    public void gameOver()
    {
        Canvas.GetComponent<GameOverMenu>().showGameOverMenu();
        isGameOver = true;
        evalGameState();
        saveHighScore();
    }

    public void saveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore1"))
        {
            //reorganize high scores
            PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));
            PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
            PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
            PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));
            PlayerPrefs.SetInt("HighScore1", score);

            
        }
        else if (score > PlayerPrefs.GetInt("HighScore2"))
        {
            //reorganize high scores
            PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));
            PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
            PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
            PlayerPrefs.SetInt("HighScore2", score);
        }
        else if (score > PlayerPrefs.GetInt("HighScore3"))
        {
            //reorganize high scores
            PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));
            PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
            PlayerPrefs.SetInt("HighScore3", score);
        }
        else if (score > PlayerPrefs.GetInt("HighScore4"))
        {
            //reorganize high scores
            PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));
            PlayerPrefs.SetInt("HighScore4", score);
        }
        else if (score > PlayerPrefs.GetInt("HighScore5"))
        {
            PlayerPrefs.SetInt("HighScore5", score);
        }
        //else your score is not saved :(
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

    public int getScore()
    {
        return score;
    }
}
