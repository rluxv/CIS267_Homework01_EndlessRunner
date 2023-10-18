using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public GameObject boundary;
    private float horizontalInput;
    private int jumpTime;
    private bool jumping;
    public float jumpForce;
    public int minJumpVal;
    public int maxJumpVal;
    private bool canJump;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumping = false;
        canJump = true;
    }

    //FixedUpdate is used for physics
    void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, playerRigidBody.velocity.y);
        //move the boundary with the player

        
        if((jumping && jumpTime < maxJumpVal) || jumpTime < minJumpVal)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            jumpTime++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Using GetAxis instead of GetAxisRaw, the player movement is a bit improved, the player will gain speed over time.
        horizontalInput = Input.GetAxis("Horizontal");
        flipPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Pressed Space");
            if (canJump)
            {
                jumping = true;
                canJump = false;
            }
        }
        
        
        if (Input.GetKey(KeyCode.Space) && jumping)
        {
            jumping = true;
            //Debug.Log("Holding down space");
        }
        else
        {
            jumping = false;
            jumpTime = 0;
        }
    }

    public void flipPlayer()
    {
        if (horizontalInput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ground" || tag == "Spike" || tag == "MovingGround")
        {
            //Debug.Log("HitGround");
            if(transform.position.y > collision.gameObject.transform.position.y)
            {
                canJump = true;
            }
            if(tag == "MovingGround")
            {
                transform.parent = collision.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ground" || tag == "Spike" || tag == "MovingGround")
        {
            canJump = false;
            if (tag == "MovingGround")
            {
                transform.parent = null;
            }
        }
    }
}
