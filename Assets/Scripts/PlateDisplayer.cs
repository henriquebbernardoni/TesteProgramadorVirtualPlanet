using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateDisplayer : MonoBehaviour
{
    private Recipe selectedRecipe;

    private bool canSelectIngredient;

    private int currentComponent = 0;
    private Ingredient[] ingredients;
    [SerializeField] private SpriteRenderer[] ingredientImages;

    private SendButton sendButton;

    private void Awake()
    {
        ingredients = new Ingredient[3];

        sendButton = FindObjectOfType<SendButton>();

        canSelectIngredient = false;
    }

    public bool GetCanSelect()
    {
        return canSelectIngredient;
    }

    public void SetSelectedRecipe(Recipe selectedRecipe)
    {
        this.selectedRecipe = selectedRecipe;
    }

    public Recipe GetSelectedRecipe()
    {
        return selectedRecipe;
    }

    public Ingredient[] GetIngredients()
    {
        return ingredients;
    }

    public void SelectIngredient(Ingredient ingredient)
    {
        canSelectIngredient = false;
        ingredients[currentComponent] = ingredient;
        ingredientImages[currentComponent].sprite = ingredient.sprite;
        ingredientImages[currentComponent].color = Color.white;

        currentComponent++;
        if (currentComponent < 3)
        {
            canSelectIngredient = true;
        }
        else
        {
            sendButton.SetButtonState(true);
        }
    }

    public void ResetSandwich()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i] = null;
            ingredientImages[i].color = Color.clear;
        }
        canSelectIngredient = true;
        currentComponent = 0;
        sendButton.SetButtonState(false);
    }

    public bool CheckSandwichComplete()
    {
        bool tempBool = false;

        if (currentComponent >= 3)
        {
            tempBool = true;
        }

        return tempBool;
    }
}