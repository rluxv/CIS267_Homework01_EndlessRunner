using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private Rigidbody2D wallRigidBody;
    public float wallMovementSpeed;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        wallRigidBody = GetComponent<Rigidbody2D>();
        time = 0;
    }

    private void FixedUpdate()
    {
        //
        time++;
        //Debug.Log("Time: " + time);
        // wait a few seconds before moving the wall
        // this will also be used to increase the wall speed as time goes on
        if (time > 100)
        {
            wallRigidBody.AddForce(transform.right * wallMovementSpeed);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // End Game
            //Debug.Log("Collided with player - ending game");
        }
    }
}
