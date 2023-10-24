using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    //This class is used to destroy objects that go too far off the screen to prevent slowdown.

    private Rigidbody2D rb2d;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * player.GetComponent<PlayerMovementHandler>().movementSpeed, player.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // we need to make sure we don't destroy the wall object otherwise the game will be broken
        if(!collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
    }
}
