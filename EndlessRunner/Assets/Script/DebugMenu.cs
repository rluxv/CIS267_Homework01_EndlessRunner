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
    public TMP_Text systemInfoTMP;
    public GameObject systemInfoGO;

    void Start()
    {

        if (debugMenuActive == false)
        {
            fpsCounterGO.SetActive(false);
            systemInfoGO.SetActive(false);
        }
        InvokeRepeating("updateFPS", 0, 1);
        systemInfoTMP.SetText("CPU: " + SystemInfo.processorType + " GPU: " + SystemInfo.graphicsDeviceName + ", " + SystemInfo.graphicsDeviceType);
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
                systemInfoGO.SetActive(true);
            }
            else
            {
                debugMenuActive = false;
                fpsCounterGO.SetActive(false);
                systemInfoGO.SetActive(false);
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
