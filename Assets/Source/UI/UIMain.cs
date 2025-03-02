using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text gameOverPanelScoreText;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        SetScore(GameMode.Instance.Score);
        
        UIEvent.OnScoreChange += OnScoreChange;
        UIEvent.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        UIEvent.OnScoreChange -= OnScoreChange;
        UIEvent.OnGameOver -= OnGameOver;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("UI_Confirm"))
        {
            if (gameOverPanel.activeSelf)
                GameMode.Instance.GameRestart();
        }
    }

    private void OnScoreChange(int score)
    {
        SetScore(score);
    }

    private void SetScore(int score)
    {
        scoreText.text = "Score : " + GameMode.Instance.Score.ToString();
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverPanelScoreText.text = "Score : " + GameMode.Instance.Score.ToString();
    }
}
