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
        playerHealth = 4;
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if(playerHealth == 4)
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
