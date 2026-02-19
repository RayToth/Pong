using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private Vector3 startPosition;

    public bool IsPlayerOne => CompareTag("PlayerOne");
    public bool IsPlayerTwo => CompareTag("PlayerTwo");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = transform.position;

        GameManager.Instance.OnReplay += ResetPosition;
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnReplay -= ResetPosition;
    }
}
