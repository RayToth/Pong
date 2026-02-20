using UnityEngine;

public class BallPaddleReflect : MonoBehaviour
{
    public float maxBounceAngle = 60f;
    public float speedIncrease = 0.5f;

    private Rigidbody2D rb;
    private Ball ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("PlayerOne") &&
            !other.gameObject.CompareTag("PlayerTwo")) return;

        // Get paddle info
        float paddleY = other.transform.position.y;
        float paddleHeight = other.bounds.size.y;

        // Calculate offset: -1 (bottom) to +1 (top)
        float hitOffset = (transform.position.y - paddleY) / (paddleHeight / 2f);
        hitOffset = Mathf.Clamp(hitOffset, -1f, 1f);

        // Determine horizontal direction (bounce away from paddle)
        float xDirection = transform.position.x < 0 ? 1f : -1f;

        // Calculate bounce angle
        float bounceAngle = hitOffset * maxBounceAngle;
        float angleRad = bounceAngle * Mathf.Deg2Rad;

        Vector2 newDir = new Vector2(xDirection * Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;

        ball.OnPaddleHit(newDir, speedIncrease);
    }
}
