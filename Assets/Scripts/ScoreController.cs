using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private PlateDisplayer plateDisplayer;
    private RecipeDisplayer recipeDisplayer;

    private TextMeshProUGUI scoreText;

    private int scoreCount;

    private void Awake()
    {
        plateDisplayer = FindObjectOfType<PlateDisplayer>();
        recipeDisplayer = FindObjectOfType<RecipeDisplayer>();

        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void RightSandwichResult()
    {
        ScoreChange(200);

        recipeDisplayer.SelectNewRecipe();
        plateDisplayer.ResetSandwich();
    }

    public void WrongSandwichResult()
    {
        ScoreChange(-150);

        plateDisplayer.ResetSandwich();
    }

    private void ScoreChange(int value)
    {
        scoreCount += value;
        scoreCount = Mathf.Clamp(scoreCount, 0, scoreCount);
        scoreText.text = scoreCount.ToString();
    }

    public int GetScore()
    {
        return scoreCount;
    }
}