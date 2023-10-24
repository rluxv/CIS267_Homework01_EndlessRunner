using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    private GameManager gm;

    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 6;
        gm = gameManager.GetComponent<GameManager>();
    }

    public void takeDamage()
    {
        if(playerHealth == 6)
        {
            playerHealth--;
            gm.takeHealthBar(6);
        }
        else if(playerHealth == 5)
        {
            playerHealth--;
            gm.takeHealthBar(5);
        }
        else if(playerHealth == 4)
        {
            playerHealth--;
            gm.takeHealthBar(4);
        } else if(playerHealth == 3)
        {
            playerHealth--;
            gm.takeHealthBar(3);
        } else if(playerHealth == 2)
        {
            playerHealth--;
            gm.takeHealthBar(2);
        } else if(playerHealth == 1)
        {
            playerHealth--;
            gm.takeHealthBar(1);
            gm.gameOver();
        }
    }
}
