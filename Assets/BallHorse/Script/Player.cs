using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.U2D.Tooling.Analyzer;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float slamForce;
    public float bounceForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int health = 1;
    public float jumpTimerMax = 1f;

    private float jumpTimer = 0f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canSlam = false;
    private bool willBounce = false;
    private bool bouncing = false;
    private bool jumpTimerRunning = false;
    private bool dead = false;
    public TextMeshProUGUI coinText;
    public ScoreCount score;
    public GameOverUI gameOverScreen;
    public Canvas gameUI;
    public BetterSpawner spawner;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateCoinText();
    }

    void Update()
    {
        if (!dead)
        {
            isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);

            if (Input.GetMouseButtonDown(0) && isGrounded && willBounce == false)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpTimer = 0f;
                jumpTimerRunning = true;
                canSlam = false;
                bouncing = false;
            }

            else if (isGrounded && willBounce == true)
            {
                print("Boing!");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
                willBounce = false;
                bouncing = true;
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

            else if (Input.GetMouseButtonDown(0) && jumpTimer == jumpTimerMax && canSlam && !isGrounded && !bouncing)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, slamForce * -1);
                willBounce = true;
            }
        }
    }

    public void Die()
    {
        score.gameOver = true;
        dead = true;
        spawner.active = false;
        spawner.DeactivateObjects();
        gameUI.gameObject.SetActive(false);
        gameOverScreen.Setup((int)(Mathf.Floor(score.Score)));
        //SceneManager.LoadScene("Menu");
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
