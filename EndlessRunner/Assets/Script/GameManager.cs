using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lifebar1;

    public GameObject lifebar2;

    public GameObject lifebar3;

    public GameObject lifebar4;
    public GameObject Canvas;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
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
}
