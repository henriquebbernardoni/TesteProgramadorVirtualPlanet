using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private TimerController timerController;
    private ScoreController scoreController;

    private RecipeDisplayer recipeDisplayer;
    private PlateDisplayer plateDisplayer;

    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private EndgameController endgamePanel;

    private AudioSource audioSource;

    private void Awake()
    {
        timerController = FindObjectOfType<TimerController>();
        scoreController = FindObjectOfType<ScoreController>();

        recipeDisplayer = FindObjectOfType<RecipeDisplayer>();
        plateDisplayer = FindObjectOfType<PlateDisplayer>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        gameplayPanel.SetActive(false);
        countdownPanel.SetActive(true);
        endgamePanel.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        countdownPanel.SetActive(false);
        gameplayPanel.SetActive(true);

        recipeDisplayer.SelectNewRecipe();
        plateDisplayer.ResetSandwich();

        StartCoroutine(timerController.TimerRoutine());

        audioSource.Play();
    }

    public void GameFinish()
    {
        audioSource.Stop();
        gameplayPanel.SetActive(false);
        endgamePanel.EndgameSequence(scoreController.GetScore());
    }
}