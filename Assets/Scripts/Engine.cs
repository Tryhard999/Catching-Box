using System;
using UnityEngine;
using System.Diagnostics;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public class Engine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] TextMeshProUGUI timerText;
    public int score = 0;
    [SerializeField] private int scoreToGetLife = 0;
    public int LiveAdderForScore = 0;
    public int lifes = 3;
    [SerializeField] bool gameOver = false;
    
    Stopwatch stopWatch = new Stopwatch();

    public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;

    void Start()
    {
        stopWatch.Start();
    }

    void Update()
    {

        scoreText.text = score.ToString();
        if (lifes < 1)
        {
            lifesText.text = "";
        }
        else
        {
            lifesText.text = lifes.ToString();
        }

        StopWatchCalc();

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }

        if (LiveAdderForScore>=scoreToGetLife)
        {
            lifes++;
            LiveAdderForScore = 0;
        }

        if (gameOver)
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
            gameOverMenu.SetActive(false);
        }

        if (gameOverMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }

        if (lifes < 1)
        {
            gameOver = true;
        }

    }

    void StopWatchCalc()
    {
        var ts = TimeSpan.FromMilliseconds(stopWatch.Elapsed.TotalMilliseconds);
        timerText.text = $"{ts.Minutes:00}:{ts.Seconds:00}";
    }

    public void ChangePauseState()
    {
        if (isPaused)
        {
            stopWatch.Start();
            isPaused = false;
        }
        else
        {
            stopWatch.Stop();
            isPaused = true;
        }
    }

    public void Restart()
    {
        stopWatch.Reset();
        SceneManager.LoadScene(2);
    }
}
