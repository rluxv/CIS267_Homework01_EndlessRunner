using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 5.0f;
    private TMP_Text guiCountdownTimer;
    void Start()
    {
        guiCountdownTimer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int time = (int)timer;
        if(timer >= 4.0)
        {
            guiCountdownTimer.SetText("");
        }
        else
        {
            guiCountdownTimer.SetText(time + "");
        }
        if(timer < 1)
        {
            guiCountdownTimer.SetText("GO!");
        }
        if(timer < 0.7)
        {
            guiCountdownTimer.SetText("");
            Destroy(this);
        }
    }
}
