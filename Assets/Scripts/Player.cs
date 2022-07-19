using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 rawInput;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;  // velocity = distance / time
        transform.position += delta;
    }
}
