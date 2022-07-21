using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
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
            Destroy(gameObject);
        }
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
}
