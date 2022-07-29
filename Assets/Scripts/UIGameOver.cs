using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;

    void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    void Start()
    {
        scoreText.text = scorekeeper.GetScore().ToString("000000000");
    }
}
