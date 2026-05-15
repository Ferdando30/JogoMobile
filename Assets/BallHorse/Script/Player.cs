using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float slamForce;
    public float bounceForce;
    public float flightForce = 7;
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
    public bool flappyBirdPhysics = false;
    public TextMeshProUGUI coinText;
    public ScoreCount score;
    public GameOverUI gameOverScreen;
    public Canvas gameUI;
    public BetterSpawner spawner;
    public CavaloBolaAnimScript animScript;
    public TrailRenderer trailRenderer;
    public ParticleSystem bounceDust;

    private bool jumpPlease = false;
    private bool keepJumpingPlease = false;
    private bool bouncePlease = false;
    private bool slamPlease = false;
    private bool flyPlease = false;
    private int tweak = 1;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateCoinText();
    }

    private void Start()
    {
        CoinCountManager.instance.carotCount = 0;
        ScoreNumber.instance.Score = 0;
        UpdateCoinText();
    }

    void Update()
    {
        if (!dead)
        {
            trailRenderer.transform.position += Vector3.right * .00001f * tweak;
            tweak *= -1;
            
            Vector3[] position = new Vector3[trailRenderer.positionCount];
            trailRenderer.GetPositions(position);
            for (int i = 0; i < position.Length; i++)
            {
                position[i].x -= 5f * Time.deltaTime;
                position[i].y += 1f * Time.deltaTime;
            }

            trailRenderer.SetPositions(position);

            if (!flappyBirdPhysics)
            {
                if (Input.GetMouseButtonDown(0) && isGrounded && willBounce == false)
                {
                    jumpPlease = true;
                    jumpTimer = 0f;
                    jumpTimerRunning = true;
                    canSlam = false;
                    bouncing = false;
                }

                else if (isGrounded && willBounce == true)
                {
                    print("Boing!");
                    bouncePlease = true;
                    willBounce = false;
                    bouncing = true;
                }

                else if (Input.GetMouseButton(0) && !isGrounded && jumpTimerRunning)
                {
                    keepJumpingPlease = true;
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
                    slamPlease = true;
                    willBounce = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    flyPlease = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (jumpPlease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPlease = false;
        }
        
        if (bouncePlease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
            bounceDust.Play();
            bouncePlease = false;
        }
        
        if (keepJumpingPlease)
        {
            rb.linearVelocity += new Vector2(rb.linearVelocity.x, 0.003f);
            keepJumpingPlease = false;
        }
        
        if (slamPlease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, slamForce * -1);
            slamPlease = false;
        }

        if (flyPlease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, flightForce);
            flyPlease = false;
        }
    }

    public void Die()
    {
        score.gameOver = true;
        dead = true;
        spawner.active = false;
        spawner.DeactivateObjects();
        gameUI.gameObject.SetActive(false);
        gameOverScreen.Setup((int)(Mathf.Floor(ScoreNumber.instance.Score)));
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animScript.anim.enabled = false;
        céu[] allCelScript = Object.FindObjectsByType<céu>(FindObjectsSortMode.None);
        foreach(céu fundo in allCelScript)
        {
            fundo.speed = 0f;
        }
        chão[] allChaoScript = Object.FindObjectsByType<chão>(FindObjectsSortMode.None);
        foreach(chão montanha in allChaoScript)
        {
            montanha.speed = 0f;
        }

    }

    public void UpdateCoinText()
    {
        if (CoinCountManager.instance != null && coinText != null)
        {
            coinText.text = $"Carrots: {CoinCountManager.instance.carotCount}";
        }
    }
}