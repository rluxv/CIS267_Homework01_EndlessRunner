using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu, gameManager;

    public void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void restartGame()
    {
        gameManager.GetComponent<GameManager>().restartGame();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
