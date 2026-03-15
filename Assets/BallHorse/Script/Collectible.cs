using UnityEngine;

public class Collectible : MonoBehaviour, IPooledObject
{
    public float moveSpeed;

    private Rigidbody2D rb;
    
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocityX = moveSpeed * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().coinCount++;
            collision.GetComponent<Player>().UpdateCoinText();
            // print(collision.GetComponent<Player>().coinCount);
            transform.position = new Vector2(10, 1);
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Despawn"))
        {
            //Destroy(gameObject);
            transform.position = new Vector2(10, 1);
        }
    }
} 