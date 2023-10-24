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
    public GameObject GameManager;
    void Start()
    {
        guiCountdownTimer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer();
    }

    public void countdownTimer()
    {
        timer -= Time.deltaTime;
        int time = (int)timer;
        if (timer >= 4.0)
        {
            guiCountdownTimer.SetText("");
        }
        else
        {
            guiCountdownTimer.SetText(time + "");
        }
        if (timer < 1)
        {
            guiCountdownTimer.SetText("GO!");
            //Unfreeze the player as soon as they see the "GO!" message
            GameManager.GetComponent<GameManager>().playerCanMove = true;
        }
        if (timer < 0.7)
        {

            guiCountdownTimer.SetText("");
            Destroy(this);
        }
    }
}
