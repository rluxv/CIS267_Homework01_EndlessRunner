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
    private bool wallMoving;
    // Start is called before the first frame update
    void Start()
    {
        wallRigidBody = GetComponent<Rigidbody2D>();
        wallMoving = false;
    }

    private void FixedUpdate()
    {
        moveWall();
    }

    // Update is called once per frame
    void Update()
    {

        timerTick();
    }

    public void moveWall()
    {
        // wait a few seconds before moving the wall
        if (seconds >= 4)
        {
            wallMoving = true;
            wallRigidBody.transform.Translate(transform.right * wallMovementSpeed);
        }
    }

    public void timerTick()
    {
        if(!wallMoving)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
        }
    }
}
