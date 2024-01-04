using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameView : MonoBehaviour
{
    private float distance;

    private float score;
    private float highScore;

    public TextMeshProUGUI scoreText, highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + distance.ToString("F");

        distance += Time.deltaTime * .8f;

        score = distance;

        if (score > highScore)
            Save();

        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {

            scoreText.text = score.ToString("F");
            highScoreText.text = highScore.ToString("F");
        }
    }

    void Save()
    {
        PlayerPrefs.SetFloat("HighScore", score);

        highScore = score;
        highScoreText.text = "" + highScore.ToString("F");
    }
}

