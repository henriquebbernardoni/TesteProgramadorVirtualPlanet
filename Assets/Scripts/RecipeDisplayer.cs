using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplayer : MonoBehaviour
{
    private Object[] allRecipes;
    private Recipe selectedRecipe;

    [SerializeField] private Image[] sandwichComponents;
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] private TextMeshProUGUI ingredientsList;

    private GameController gameController;
    private PlateDisplayer plateDisplayer;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        plateDisplayer = FindObjectOfType<PlateDisplayer>();

        allRecipes = Resources.LoadAll("", typeof(Recipe));
    }

    public void SelectNewRecipe()
    {
        Recipe newSelectedRecipe = selectedRecipe;

        while (newSelectedRecipe == selectedRecipe)
        {
            newSelectedRecipe = (Recipe)allRecipes[Random.Range(0, allRecipes.Length)];
        }

        selectedRecipe = newSelectedRecipe;
        plateDisplayer.SetSelectedRecipe(selectedRecipe);
        RecipeDisplayUpdate();
    }

    private void RecipeDisplayUpdate()
    {
        if (!selectedRecipe)
        {
            for (int i = 0; i < sandwichComponents.Length; i++)
            {
                sandwichComponents[i].color = Color.clear;
            }
            recipeName.text = null;
            ingredientsList.text = null;

            return;
        }

        string tempIngredientList = null;

        for (int i = 0; i < sandwichComponents.Length; i++)
        {
            sandwichComponents[i].sprite = selectedRecipe.Ingredients[i].sprite;
            tempIngredientList += selectedRecipe.Ingredients[i].ingredientName + "\n";
        }
        recipeName.text = selectedRecipe.recipeName;
        ingredientsList.text = tempIngredientList;
    }

    public Recipe GetRecipe()
    {
        return selectedRecipe;
    }
}