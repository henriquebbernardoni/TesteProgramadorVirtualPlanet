using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private GameController gameController;

    private int totalTime = 30;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        StartCoroutine(TimerRoutine());
    }

    public IEnumerator TimerRoutine()
    {
        int timeLeft = totalTime;

        while (timeLeft >= 0)
        {
            if (timeLeft <= 10)
            {
                timerText.color = Color.red;
            }

            timerText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        gameController.GameFinish();
    }
}