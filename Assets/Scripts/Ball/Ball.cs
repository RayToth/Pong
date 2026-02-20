using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem hitEffectPrefab;

    [SerializeField] private float baseSpeed = 5f;

    private float currentSpeed;
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


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerOne") || col.gameObject.CompareTag("PlayerTwo"))
        {
            ParticleSystem effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            var vel = effect.velocityOverLifetime;
            vel.enabled = true;
            vel.x = (col.CompareTag("PlayerOne")) ? 2f : -2f;
            vel.y = 0f;
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);

            var main = effect.main;
            main.startRotation = (col.CompareTag("PlayerOne")) ? Mathf.PI / 2 : -Mathf.PI / 2;
        }
    }

    private Vector2 GetRandomDirection()
    {
        float maxAngle = 30f;
        float angle = Random.Range(-maxAngle, maxAngle);
        float angleRad = angle * Mathf.Deg2Rad;

        float xDirection = Random.value > 0.5f ? 1f : -1f;

        return new Vector2(xDirection * Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;
    }
    public void PushBall()
    {
        currentSpeed = baseSpeed;
        rb.velocity = GetRandomDirection() * currentSpeed;
    }

    public void OnPaddleHit(Vector2 newDirection, float speedIncrease)
    {
        currentSpeed += speedIncrease;
        rb.velocity = newDirection * currentSpeed;
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
