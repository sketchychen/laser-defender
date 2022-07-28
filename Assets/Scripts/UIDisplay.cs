using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;

    int score = 0;
    float health = 1f;

    void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        UpdateScoreText();
        UpdateHealthSlider();
    }

    void UpdateScoreText()
    {
        scoreText.text = scorekeeper.GetScore().ToString("000000000"); // or $"{scorekeeper.GetScore():000000000}"
    }

    void UpdateHealthSlider()
    {
        healthSlider.value = playerHealth.GetHealth();
    }
}
