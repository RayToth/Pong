using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = gameObject.transform.position;
        PushBall();
        GameManager.Instance.OnRoundReset += OnNewRound;
        GameManager.Instance.OnReplay += OnNewRound;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnRoundReset -= OnNewRound;
        GameManager.Instance.OnReplay -= OnNewRound;
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
        rb.velocity = GetRandomDirection() * baseSpeed;
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
