using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public float slopeSpeed;
    public float moveMultiplier;
    public bool moving = true;

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            rb.linearVelocityX = moveSpeed * -1 * moveMultiplier;
            rb.linearVelocityY = slopeSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health--;
            if (collision.GetComponent<Player>().health <= 0)
            {
                collision.GetComponent<Player>().Die();
            }
        }
        if (collision.gameObject.CompareTag("Despawn"))
        {
            //collision.GetComponent<Reference>().obstacleSpawner.GetComponent<ObstacleSpawner>().obstacleCount--;
            transform.position = new Vector2(10, -1);
            Standby();
        }

    }
    private void Standby()
    {
        gameObject.SetActive(false);
        if (BetterSpawner.instance.activeObjects.Contains(gameObject))
        {
            BetterSpawner.instance.activeObjects.Remove(gameObject);
        }
    }
}