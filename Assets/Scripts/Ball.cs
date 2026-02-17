using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = gameObject.transform.position;
    }

    private void Start()
    {
        PushBall();
        GameManager.Instance.OnRoundReset += OnNewRound;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnRoundReset -= OnNewRound;
    }

    private Vector2 GetRandomDirection()
    {
        Vector2 direction = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );

        // If both values are 0, then set direction to [1, 1]
        if (direction.magnitude < 0.1f)
        {
            direction = Vector2.one;
        }

        return direction.normalized;
    }
    public void PushBall()
    {
        rb.velocity = GetRandomDirection() * moveSpeed;
    }

    private void ResetPosition()
    {
        gameObject.transform.position = startPosition;
    }

    private void OnNewRound()
    {
        ResetPosition();
        PushBall();
    }
}
