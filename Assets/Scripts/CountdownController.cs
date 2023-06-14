using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    private int countdown = 3;
    private TextMeshProUGUI countdownText;
    [SerializeField] private GameController gameController;

    private void Awake()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        gameController = FindObjectOfType<GameController>();
    }

    //Essa função altera o valor que é apresentado na contagem regressiva.
    public void CountdownSetter()
    {
        if (countdown == 0)
        {
            countdownText.text = "Comece!";
            return;
        }

        countdownText.text = countdown.ToString();
        countdown--;
    }

    //Essa função será acionada quando a contagem regressiva acabar.
    public void CountdownFinish()
    {
        gameController.GameStart();
    }
}