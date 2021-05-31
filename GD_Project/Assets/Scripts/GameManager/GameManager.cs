using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text pauseButtonText;
    private static GameManager singletonInstance;
    public Text scoreText;
    private int globalScore = 0;
    public Text highScoreText;
    private bool isPaused = false;
    
    bool endedGame=false;
    // Start is called before the first frame update
    public float restartDelay=2f;

    private void Awake()
    {
        if (singletonInstance == null)
        {
            singletonInstance = this;
        }
    }

 
    private void Start()
    {
        pauseButtonText.text = "Pause"; 
        isPaused = false;
        globalScore = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public static GameManager GetInstance()
    {
        return singletonInstance;
    }
    public void IncrementScore(int value)
    {
        globalScore += value;
        scoreText.text = globalScore.ToString();

    }

    public void EndGame()
    {
        if(endedGame==false)
        {
            endedGame=true;
            Debug.Log("Game Over");
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (highScore < globalScore)
            {
                PlayerPrefs.SetInt("HighScore", globalScore);
                highScoreText.text = globalScore.ToString();

            }
            Invoke("Restart",restartDelay);
        }
        
    }

    // Update is called once per frame
    void Restart()
    {
        //aici se poate da load la urmatorul nivel
        SceneManager.LoadScene("MainScene");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PauseButton()
    {
        isPaused = !isPaused;
        Time.timeScale = (isPaused) ? 0 : 1;
        pauseButtonText.text = (isPaused) ? "Resume" : "Pause";
    }
   
}
