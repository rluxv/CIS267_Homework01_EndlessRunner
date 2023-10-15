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
        if(collision.gameObject.CompareTag("Spike"))
        {
            if(!gm.spikeShieldActive)
            {
                GetComponent<PlayerHealth>().takeDamage();
            }
            else
            {
                gm.spikeShieldHits--;
                if(gm.spikeShieldHits <= 0)
                {
                    gm.spikeShieldActive = false;
                    transform.Find("SpikeShield").gameObject.SetActive(false);
                }
            }
        }
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
            gm.gameOver();
        }
        else if(collision.gameObject.CompareTag("TerrainEndScoreCollider"))
        {
            gm.addScore(collision.gameObject.GetComponent<TerrainScoreCollider>().scoreValue);
            //Destroy the collider object so the player cant go back and get more score for beating a level
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("SpikeShieldCollectible"))
        {
            gm.spikeShieldActive = true;
            //this means a player can hit a spike 10 times before the spike shield is removed
            gm.spikeShieldHits = 10;
            //add some score for getting a collectible
            gm.addScore(25);

            Destroy(collision.gameObject);
            transform.Find("SpikeShield").gameObject.SetActive(true);

        }
    }
}
