using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{
    private PlateDisplayer plateDisplayer;
    private ScoreController scoreController;

    private Button sendButton;
    private AudioSource audioSource;

    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    private void Awake()
    {
        plateDisplayer = FindObjectOfType<PlateDisplayer>();
        scoreController = FindObjectOfType<ScoreController>();

        sendButton = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        sendButton.onClick.AddListener(SendButtonBehaviour);
    }

    public void SetButtonState(bool state)
    {
        sendButton.interactable = state;
    }

    public void SendButtonBehaviour()
    {
        if (DishDetermination())
        {
            scoreController.RightSandwichResult();
            audioSource.PlayOneShot(correctSound);
        }
        else
        {
            scoreController.WrongSandwichResult();
            audioSource.PlayOneShot(wrongSound);
        }
    }

    public bool DishDetermination()
    {
        Ingredient[] correctIngredients = plateDisplayer.GetSelectedRecipe().Ingredients;
        Ingredient[] selectedIngredients = plateDisplayer.GetIngredients();
        bool result = true;

        for (int i = 0; i < correctIngredients.Length; i++)
        {
            if (correctIngredients[i] != selectedIngredients[i])
            {
                result = false;
                break;
            }
        }

        return result;
    }
}