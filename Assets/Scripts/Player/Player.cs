using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    public bool IsPlayerOne => CompareTag("PlayerOne");
    public bool IsPlayerTwo => CompareTag("PlayerTwo");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
