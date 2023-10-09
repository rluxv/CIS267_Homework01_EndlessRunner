using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    private GameManager gm;

    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            GetComponent<PlayerHealth>().takeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // we assign the wall tag to the water below the player as well
        if (collision.gameObject.CompareTag("Wall"))
        {
            // end game instantly
           // SceneManager.LoadScene("MainMenu");
        }
    }
}
