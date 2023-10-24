using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool debugMenuActive;
    public TMP_Text fpsCounterTMP;
    public GameObject fpsCounterGO;
    void Start()
    {

        if(debugMenuActive == false) fpsCounterGO.SetActive(false);

        InvokeRepeating("updateFPS", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if(!debugMenuActive)
            {
                debugMenuActive = true;
                fpsCounterGO.SetActive(true);
            }
            else
            {
                debugMenuActive = false;
                fpsCounterGO.SetActive(false);
            }
        }
    }

    public void updateFPS()
    {
        if (debugMenuActive)
        {
            float fps = 1.0f / Time.deltaTime;
            int fpsInt = (int)fps;
            fpsCounterTMP.SetText("FPS: " + fpsInt);
        }
    }

}
