using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int coinCount = 0;
    public int health = 1;
    public float jumpTimer = 0f;
    public float jumpTimerMax = 1f;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpTimerRunning = false;

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
            jumpTimer = 0f;
            jumpTimerRunning = true;
        }
        
        else if (Input.GetMouseButton(0) && !isGrounded && jumpTimerRunning)
        {
            rb.linearVelocity += new Vector2(rb.linearVelocity.x, 0.002f);
        }
        else if (Input.GetMouseButton(0) == false)
        {
            jumpTimer = jumpTimerMax;
        }

        if (jumpTimerRunning == true && jumpTimer < jumpTimerMax)
        {
            jumpTimer += Time.deltaTime;
        }

        else if (jumpTimerRunning && jumpTimer >= jumpTimerMax)
        {
            jumpTimerRunning = false;
        }

    }

    public void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ballhorse");
    }
}
