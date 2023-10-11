using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private Rigidbody2D wallRigidBody;
    public float wallMovementSpeed;
    public GameObject player;
    float timer = 0.0f;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        wallRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Debug.Log("Time: " + time);
        // wait a few seconds before moving the wall
        // this will also be used to increase the wall speed as time goes on
        if (seconds >= 4)
        {
            wallRigidBody.transform.Translate(transform.right * wallMovementSpeed);
            transform.position = new Vector3(transform.position.x, player.transform.position.y);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
    }
}
