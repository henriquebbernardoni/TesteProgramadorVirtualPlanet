using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelection : MonoBehaviour
{
    private PlateDisplayer plateDisplayer;

    [SerializeField] private Ingredient ingredient;

    private void Awake()
    {
        plateDisplayer = FindObjectOfType<PlateDisplayer>();
    }

    private void OnMouseDown()
    {
        if (plateDisplayer.GetCanSelect())
        {
            plateDisplayer.SelectIngredient(ingredient);
        }
    }
}