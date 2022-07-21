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
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;  // Range constrains values within bounds

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float dmaageVolume = 1f;


    public void PlayShootingClip()
    {
        PlayClip(shootingClip);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip);
    }

    void PlayClip(AudioClip clip)
    {
        if (clip == !null) { return; }
        AudioSource.PlayClipAtPoint(clip,
                                    Camera.main.transform.position,
                                    dmaageVolume);
    }

}
