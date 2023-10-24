using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        fitAspectRatio();
    }

    public void fitAspectRatio()
    {
        if (Camera.main.aspect >= 1.7) //if 16:9 do nothing, its already good
        {
            //Debug.Log("AspectRatio 16:9");
        }
        else if (Camera.main.aspect > 1.6 || Camera.main.aspect == 1.6)// 5:3/16:10
        {
            //Debug.Log("AspectRatio 5:3/16:10");
            transform.position = new Vector3(-0.9f, 0.0f, 0.0f);
        }
        else if (Camera.main.aspect >= 1.5)// 3:2
        {
            //Debug.Log("AspectRatio 3:2");
            transform.position = new Vector3(-1.4f, 0.0f, 0.0f);
        }
        else // 4:3
        {
            //Debug.Log("AspectRatio 4:3");
            transform.position = new Vector3(-2.2f, 0.0f, 0.0f);
        }
    }
}
