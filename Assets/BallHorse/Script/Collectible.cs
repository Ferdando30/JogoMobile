using UnityEngine;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour, IPooledObject
{
    public float moveSpeed;
    public float slopeSpeed;
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
            rb.linearVelocityX = moveSpeed * -1 * ScoreNumber.instance.moveMultiplier;
            rb.linearVelocityY = slopeSpeed * ScoreNumber.instance.moveMultiplier;
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
            Player player = collision.GetComponent<Player>();
            
            if (player.powerup != "Multiplier")
            { 
            CoinCountManager.instance.carotCount++;
            TotalCarots.instance.CarrotUp();
            player.UpdateCoinText();
            transform.position = new Vector2(10, 1);
            Standby();
            }
            
            else
            {
                CoinCountManager.instance.carotCount++;
                CoinCountManager.instance.carotCount++;
                TotalCarots.instance.CarrotUp();
                TotalCarots.instance.CarrotUp();
                player.UpdateCoinText();
                transform.position = new Vector2(10, 1);
                Standby();
            }
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