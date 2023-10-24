using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public TMP_Text highScore3;
    public TMP_Text highScore4;
    public TMP_Text highScore5;

    public void StartGame()
    {
        SceneManager.LoadScene("RunnerScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void showHighScores()
    {
        transform.Find("HighScores").gameObject.SetActive(true);
        transform.Find("MainMenu").gameObject.SetActive(false);


        int highScore1i = PlayerPrefs.GetInt("HighScore1");
        if(highScore1i == 0)
        {
            highScore1.SetText("High Score 1: No Data Saved");
        }
        else
        {
            highScore1.SetText("High Score 1: " + highScore1i);
        }

        int highScore2i = PlayerPrefs.GetInt("HighScore2");
        if (highScore2i == 0)
        {
            highScore2.SetText("High Score 2: No Data Saved");
        }
        else
        {
            highScore2.SetText("High Score 2: " + highScore2i);
        }

        int highScore3i = PlayerPrefs.GetInt("HighScore3");
        if (highScore3i == 0)
        {
            highScore3.SetText("High Score 3: No Data Saved");
        }
        else
        {
            highScore3.SetText("High Score 3: " + highScore3i);
        }

        int highScore4i = PlayerPrefs.GetInt("HighScore4");
        if (highScore4i == 0)
        {
            highScore4.SetText("High Score 4: No Data Saved");
        }
        else
        {
            highScore4.SetText("High Score 4: " + highScore4i);
        }

        int highScore5i = PlayerPrefs.GetInt("HighScore5");
        if (highScore5i == 0)
        {
            highScore5.SetText("High Score 5: No Data Saved");
        }
        else
        {
            highScore5.SetText("High Score 5: " + highScore5i);
        }


    }

    public void showMainMenu()
    {
        transform.Find("HighScores").gameObject.SetActive(false);
        transform.Find("MainMenu").gameObject.SetActive(true);
    }
}
