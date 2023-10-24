using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset;

    [Tooltip("0 to move left and right | 1 to move up and down")] public int movementDirection;


    private float startPosX;
    private float startPosY;
    public float movementSpeed;
    public bool moveLeft;
    public bool moveUp;
    void Start()
    {
        //we need to save the starting position so we know how far to go
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //If we are moving left and right
        if(movementDirection == 0)
        {
            if (moveLeft)
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }

            if (transform.position.x >= startPosX + offset)
            {
                moveLeft = true;
            }
            if (transform.position.x <= startPosX - offset)
            {
                moveLeft = false;
            }
        }
        //If we are moving up and down
        else if(movementDirection == 1)
        {
            if (moveUp)
            {
                transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
            }

            if (transform.position.y <= startPosY - offset)
            {
                moveUp = true;
            }
            if (transform.position.y >= startPosY + offset)
            {
                moveUp = false;
            }
        }
    }
}
