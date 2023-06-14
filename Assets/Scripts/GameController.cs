using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private TimerController timerController;
    private ScoreController scoreController;

    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private GameObject gameUIPanel;
    
    private void Awake()
    {
        timerController = FindObjectOfType<TimerController>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        gameUIPanel.SetActive(false);
    }

    public void GameStart()
    {
        countdownPanel.SetActive(false);
        gameUIPanel.SetActive(true);

        StartCoroutine(timerController.TimerRoutine());
    }

    public void GameFinish()
    {
        gameUIPanel.SetActive(false);
    }
}