using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int coinCount = 0;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        if (Input.GetMouseButton(0) && isGrounded) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCount++;
            print(coinCount);
        }
    }
}
