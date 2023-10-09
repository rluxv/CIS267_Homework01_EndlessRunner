using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private Rigidbody2D wallRigidBody;
    public float wallMovementSpeed;
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
            wallRigidBody.AddForce(transform.right * wallMovementSpeed);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
    }
}
