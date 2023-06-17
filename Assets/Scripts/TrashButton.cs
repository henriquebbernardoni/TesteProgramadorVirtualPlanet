using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashButton : MonoBehaviour
{
    private PlateDisplayer plateDisplayer;

    private Button trashButton;
    private AudioSource audioSource;

    private void Awake()
    {
        plateDisplayer = FindObjectOfType<PlateDisplayer>();

        trashButton = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        trashButton.onClick.AddListener(TrashButtonBehaviour);
    }

    public void TrashButtonBehaviour()
    {
        plateDisplayer.ResetSandwich();
        audioSource.Play();
    }
}