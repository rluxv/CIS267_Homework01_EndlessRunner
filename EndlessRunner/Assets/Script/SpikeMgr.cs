using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMgr : MonoBehaviour
{
    // Start is called before the first frame update
    private bool spikeShowing;
    private Vector3 startingLocation;
    private float startLocX;
    private float startLocY;
    public float timeSpikeHiding;
    public float timeSpikeShowing;
    float timer = 0.0f;
    void Start()
    {
        startingLocation = transform.position;
        spikeShowing = false;
        startLocX = transform.position.x;
        startLocY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeSpikeHiding && !spikeShowing)
        {
            transform.position = new Vector3(transform.position.x, (float)(transform.position.y + 0.7));
            spikeShowing = true;
            timer = 0;
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        else if (timer >= timeSpikeShowing && spikeShowing)
        {
            transform.position = startingLocation;
            spikeShowing = false;
            timer = 0;
            GetComponent<PolygonCollider2D>().enabled = false;

        }
    }
}
