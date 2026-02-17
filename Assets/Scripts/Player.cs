using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private string PlayerOneTag = "PlayerOne";
    private string PlayerTwoTag = "PlayerTwo";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveDirection = 0f;

        if (isPlayerOne())
        {
            if (Input.GetKey(KeyCode.W)) moveDirection += 1f;
            if (Input.GetKey(KeyCode.S)) moveDirection -= 1f;
        }

        if (isPlayerTwo())
        {
            if (Input.GetKey(KeyCode.UpArrow)) moveDirection += 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveDirection -= 1f;
        }

        rb.velocity = new Vector2(0, moveDirection * moveSpeed);
    }

    private bool isPlayerOne()
    {
        if (gameObject.tag == PlayerOneTag)
        {
            return true;
        }

        return false;
    }

    private bool isPlayerTwo()
    {
        if (gameObject.tag == PlayerTwoTag)
        {
            return true;
        }

        return false;
    }
}
