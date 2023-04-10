using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    private int playerScore;
    private int playerCorrectScore, playerFalseScore;
    private float totalTime;
    private string textName = "";


    private void OnEnable()
    {
        playerScore = PlayerPrefs.GetInt("playerscore");
        playerCorrectScore = PlayerPrefs.GetInt("playercorrectscore");
        playerFalseScore = PlayerPrefs.GetInt("playerfalsescore");

        totalTime = PlayerPrefs.GetFloat("totaltime");

        textName = gameObject.name;

        switch (textName)
        {
            case ("LevelText"):
                GetComponent<Text>().text = "" + ((int)playerScore / 1000 + 1);
                break;
            case ("ScoreText"):
                GetComponent<Text>().text = playerScore.ToString();
                break;
            case ("TimeText"):
                GetComponent<Text>().text = "" + (int)((totalTime) / ((double)(playerCorrectScore + playerFalseScore)));
                break;
        }
    }
}
