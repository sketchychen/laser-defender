using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;

    int score = 0;
    float health = 1f;

    void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
        playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
    }

    void Start()
    {
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.GetHealth();
        }
    }

    void Update()
    {
        UpdateScoreText();
        UpdateHealthSlider();
    }

    void UpdateScoreText()
    {
        if (scorekeeper != null)
        {
            scoreText.text = $"{scorekeeper.GetScore():000000000}";
        }
    }

    void UpdateHealthSlider()
    {
        if (playerHealth != null)
        {
            healthSlider.value = playerHealth.GetHealth();
        }
    }
}
