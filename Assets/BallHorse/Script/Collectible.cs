using UnityEngine;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour, IPooledObject
{
    public float moveSpeed;
    public float moveMultiplier;

    private Rigidbody2D rb;
    
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocityX = moveSpeed * -1 * moveMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinCountManager.instance.carotCount++;
            TotalCarots.instance.CarrotUp();
            collision.GetComponent<Player>().UpdateCoinText();
            //print(collision.GetComponent<Player>().coinCount);
            collision.GetComponent<Reference>().coinSpawner.GetComponent<CoinSpawner>().coinCount--;
            transform.position = new Vector2(10, 1);
            Standby();
        }
        if (collision.gameObject.CompareTag("Despawn"))
        {
            collision.GetComponent<Reference>().coinSpawner.GetComponent<CoinSpawner>().coinCount--;
            transform.position = new Vector2(10, 1);
            Standby();
        }
    }

    private void Standby()
    {
        gameObject.SetActive(false);
    }
} 