using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = moveSpeed * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().coinCount++;
            print(collision.GetComponent<Player>().coinCount);
            Destroy(gameObject);
        }
    }
} 