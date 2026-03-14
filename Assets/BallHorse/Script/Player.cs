using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int coinCount = 0;
    public int health = 1;
    public float jumpTimerMax = 1f;

    private float jumpTimer = 0f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpTimerRunning = false;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateCoinText();
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
            rb.linearVelocity += new Vector2(rb.linearVelocity.x, 0.003f);
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

    public void UpdateCoinText()
    {
        coinText.text = $"Coins: {coinCount}";
    }
}
