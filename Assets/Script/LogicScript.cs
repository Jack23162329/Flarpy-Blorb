using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour {
    public int playerScore;
    public Text scoreText;
    public Text highestText;
    public int highestScore; // Since we can't use text compare the number to score, we need anohter int to keep the highest value and then set it back to highestText
    public GameObject gameOverScreen;
    //public AudioSource PointSound;

    void Start() {

        highestText.text = PlayerPrefs.GetString("Highest");
        highestScore = PlayerPrefs.GetInt("HighestInt");
    }

    [ContextMenu("Score")]
    public void addScore(int scoreToAdd) {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        //PointSound.Play();

    }
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeSong(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }
    public void gameOver() {
        gameOverScreen.SetActive(true);
        if (playerScore > highestScore) {
            highestScore = playerScore;
            highestText.text = highestScore.ToString();
            PlayerPrefs.SetString("Highest", highestText.text);
            PlayerPrefs.SetInt("HighestInt", highestScore);
        }

    }
}
