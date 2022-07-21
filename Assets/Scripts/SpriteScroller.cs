using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveVelocity;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        if (material == null) { return; }
        offset = moveVelocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
