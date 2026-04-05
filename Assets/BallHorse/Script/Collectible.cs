using UnityEngine;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour, IPooledObject
{
    public float moveSpeed;
    public float slopeSpeed;
    public float moveMultiplier;
    public bool moving = true;

    private Rigidbody2D rb;
    
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
            CoinCountManager.instance.carotCount++;
            TotalCarots.instance.CarrotUp();
            collision.GetComponent<Player>().UpdateCoinText();
            transform.position = new Vector2(10, 1);
            Standby();
        }
        
        if (collision.gameObject.CompareTag("Despawn"))
        {
            transform.position = new Vector2(10, 1);
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