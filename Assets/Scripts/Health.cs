using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] bool isPlayer = false;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    Scorekeeper scorekeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scorekeeper = FindObjectOfType<Scorekeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer == null) { return; }
        // Take damage
        TakeDamage(damageDealer.GetDamageDealt());
        // release the explosion particles
        PlayHitEffect();
        // tell damage dealer that it hit something
        damageDealer.Hit();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        ShakeCamera();
        audioPlayer.PlayDamageClip();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scorekeeper.UpdateScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }

    private void ShakeCamera()
    {
        if (cameraShake == null) { return; }
        if (applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect == null) { return; }
        ParticleSystem instance = Instantiate(hitEffect,
                                            transform.position,
                                            Quaternion.identity);
        Destroy(instance.gameObject,
                instance.main.duration + instance.main.startLifetime.constantMax);
    }

    public int GetHealth()
    {
        return health;
    }
}
