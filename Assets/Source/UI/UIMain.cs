using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        SetScore(GameMode.Instance.Score);
        
        UIEvent.OnScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        UIEvent.OnScoreChange -= OnScoreChange;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnScoreChange(int score)
    {
        SetScore(score);
    }

    private void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
