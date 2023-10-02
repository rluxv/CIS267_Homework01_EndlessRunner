using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private float horizontalInput;
    private int jumpTime;
    private bool jumping;
    public float jumpForce;
    public int minJumpVal;
    public int maxJumpVal;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    //FixedUpdate is used for physics
    void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, playerRigidBody.velocity.y);
        
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

        if (Input.GetKey(KeyCode.Space))
        {
            jumping = true;
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
}
