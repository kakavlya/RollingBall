using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ObstacleGenerator _obstacleGenerator;
    [SerializeField] private CoinLinesGenerator _coinLineGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _ball.GameOver += GameOver;
    }

    void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _ball.GameOver += GameOver;
    }

    void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _ball.GameOver -= GameOver;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _obstacleGenerator.ResetPool();
        _coinLineGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _ball.Reset();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

}
