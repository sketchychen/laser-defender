using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.1f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0.3f;
    [SerializeField] float minFiringRate = 0.1f;

    bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    public void SetIsFiring(bool value)
    {
        isFiring = value;
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);
            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(GetRandomFireRate());
        }
    }

    float GetRandomFireRate()
    {
        float waitTime = Random.Range(baseFiringRate - firingRateVariance,
                                        baseFiringRate + firingRateVariance);
        return Mathf.Clamp(waitTime, minFiringRate, float.MaxValue);
        /* float.MaxValue is the maximum number a float can hold */
    }
}
