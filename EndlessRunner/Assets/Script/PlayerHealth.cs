using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 4;
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
            GameObject destroyObj;
            destroyObj = GameObject.FindGameObjectWithTag("Lifebar4");
            Destroy(destroyObj);
        }
    }
}
