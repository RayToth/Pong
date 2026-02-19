using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 5f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;
    [HideInInspector] public float moveSpeedMultiplier = 1f;

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveDirection = 0f;

        if (player.IsPlayerOne)
        {
            if (Input.GetKey(KeyCode.W)) moveDirection += 1f;
            if (Input.GetKey(KeyCode.S)) moveDirection -= 1f;
        }

        if (player.IsPlayerTwo)
        {
            if (Input.GetKey(KeyCode.UpArrow)) moveDirection += 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveDirection -= 1f;
        }

        player.rb.velocity = new Vector2(0, moveDirection * baseMoveSpeed * moveSpeedMultiplier);

        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
