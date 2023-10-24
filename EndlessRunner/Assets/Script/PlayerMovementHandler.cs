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
    public GameObject gameManagerObject;
    private GameManager gameManager;
    public float movementSpeed;
    private float originalSpeed;
    public float coffeeSpeed;
    public float coffeeCrashSpeed;
    private float coffeeTimer;
    public float coffeeTime;
    public float coffeeCrashTime;
    private bool isCoffee;
    private bool isCoffeeCrash;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumping = false;
        canJump = true;
        gameManager = gameManagerObject.GetComponent<GameManager>();
        originalSpeed = movementSpeed;
        isCoffee = false;
        isCoffeeCrash = false;
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
        //Debug.Log("FPS: " + 1.0f / Time.deltaTime);
        coffee();
        movePlayer();
    }

    public void movePlayer()
    {
        if (gameManager.playerCanMove)
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
        if (tag == "Ground" || tag == "Spike" || tag == "MovingGround" || tag == "Lavablock")
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
        if (tag == "Spike") canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ground" || tag == "MovingGround" || tag == "Lavablock")
        {
            canJump = false;
            if (tag == "MovingGround")
            {
                transform.parent = null;
            }
        }
    }

    public void coffee()
    {
        if(isCoffee)
        {
            coffeeTimer -= Time.deltaTime;
            if (coffeeTimer <= 0)
            {
                movementSpeed = coffeeCrashSpeed;
                isCoffeeCrash = true;
                coffeeTimer = coffeeCrashTime;
                isCoffee = false;
            }
        }
        else if (isCoffeeCrash)
        {
            coffeeTimer -= Time.deltaTime;
            if (coffeeTimer <= 0)
            {
                movementSpeed = originalSpeed;
                isCoffeeCrash = false;
            }
        }
    }

    public void startCoffee()
    {
        //if coffee powerup already reset the timer
        if (isCoffee)
        {
            coffeeTimer = coffeeTime;
            movementSpeed = coffeeSpeed;
            isCoffee = true;
        }
        //If in coffee crash, ignore coffee crash and reset everything
        else if(isCoffeeCrash)
        {
            isCoffeeCrash = false;
            isCoffee = true;
            movementSpeed = coffeeSpeed;
        }
        // else start coffee
        else
        {
            coffeeTimer = coffeeTime;
            movementSpeed = coffeeSpeed;
            isCoffee = true;
        }
    }
}
