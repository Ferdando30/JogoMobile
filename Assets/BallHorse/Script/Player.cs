using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float slamForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // public int coinCount = 0;
   //CoinCountManager manager;
    public int health = 1;
    public float jumpTimerMax = 1f;

    private float jumpTimer = 0f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canSlam = false;
    private bool jumpTimerRunning = false;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateCoinText();
        //manager = FindFirstObjectByType<CoinCountManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        if (Input.GetMouseButtonDown(0) && isGrounded) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpTimer = 0f;
            jumpTimerRunning = true;
            canSlam = false;
        }
        
        else if (Input.GetMouseButton(0) && !isGrounded && jumpTimerRunning)
        {
            rb.linearVelocity += new Vector2(rb.linearVelocity.x, 0.003f);
        }
        
        else if (Input.GetMouseButton(0) == false)
        {
            jumpTimer = jumpTimerMax;
            canSlam = true;
        }

        if (jumpTimerRunning == true && jumpTimer < jumpTimerMax)
        {
            jumpTimer += Time.deltaTime;
        }

        else if (jumpTimerRunning && jumpTimer >= jumpTimerMax)
        {
            jumpTimerRunning = false;
        }

        else if (Input.GetMouseButtonDown(0) && jumpTimer == jumpTimerMax && canSlam && !isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, slamForce * -1);
        }

    }

    public void Die()
    {
        SceneManager.LoadScene("Menu");
        CoinCountManager.instance.carotCount = 0;
    }

    public void UpdateCoinText()
    {
        if (CoinCountManager.instance != null && coinText != null)
        {
            coinText.text = $"Carrots: {CoinCountManager.instance.carotCount}";
        }
    }
}
