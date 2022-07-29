using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    /*
    shooting, damage, death
    */

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    // Range constrains serialized value within bounds

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    /* for ManageSingletonTheBetterWay */
    static AudioPlayer instance;
    // 'static' persists through all instances of a class. private static by default
    /*
    Optional: create a 'public AudioPlayer GetInstance()'
    Pros: No need to use FindObjectOfType<AudioPlayer>
    Cons: a public getter method means easily losing track of where the singleton is used as game scope scales
    */

    void Awake()
    {
        // ManageSingletonTheOldWay();
        ManageSingletonTheBetterWay();
    }

    void ManageSingletonTheBetterWay()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null) { return; }
        AudioSource.PlayClipAtPoint(clip,
                                    Camera.main.transform.position,
                                    volume);
    }

    // void ManageSingletonTheOldWay()
    // {
    //     int instanceCount = FindObjectsOfType(GetType()).Length;
    //     if (instanceCount > 1)
    //     {
    //         gameObject.SetActive(false);
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

}
