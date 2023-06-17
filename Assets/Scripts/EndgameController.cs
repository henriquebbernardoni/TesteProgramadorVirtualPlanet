using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgameController : MonoBehaviour
{
    private Button restartButton;
    private TextMeshProUGUI finalScoreText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        restartButton = transform.Find("RestartButton").GetComponent<Button>();
        finalScoreText = transform.Find("FinalScore").GetComponent<TextMeshProUGUI>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndgameSequence(int finalScore)
    {
        gameObject.SetActive(true);
        finalScoreText.text = finalScore.ToString();
        audioSource.PlayOneShot(clip);
    }
}