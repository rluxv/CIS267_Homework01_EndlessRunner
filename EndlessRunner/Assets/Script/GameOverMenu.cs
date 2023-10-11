using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu, gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
