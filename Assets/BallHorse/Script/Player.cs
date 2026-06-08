using UnityEngine;
using System.Collections;
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

    private float powerupTimer = 0f;
    private float jumpTimer = 0f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAlmostGrounded;
    private bool canSlam = false;
    private bool willBounce = false;
    private bool bouncing = false;
    private bool finishedBounce = false;
    private bool jumpTimerRunning = false;
    private bool hover = false;
    private bool bufferJump = false;
    public bool dead = false;
    public string powerup = "None";
    public TextMeshProUGUI coinText;
    public ScoreCount score;
    public GameOverUI gameOverScreen;
    public Canvas gameUI;
    public BetterSpawner spawner;
    public PlayerSkinChanger animScript;
    public TrailRenderer trailRenderer;
   // public ParticleSystem bounceDust;

    private bool jumpPlease = false;
    private bool keepJumpingPlease = false;
    private bool bouncePlease = false;
    private bool slamPlease = false;
    private bool flyPlease = false;
    private bool queueJumpPlease = false;
    private int tweak = 1;

    public Pause pauseScript;

    


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
        UpdateSkin();
    }

    void Update()
    {
        if (!dead && !pauseScript.isPaused)
        {
            isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
            isAlmostGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.05f, 2f), CapsuleDirection2D.Horizontal, 0, groundLayer);

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

            if (powerup != "Flight")
            {
                if (isGrounded)
                {
                    hover = false;
                    keepJumpingPlease = false;
                }

                if (Input.GetMouseButtonDown(0) && isGrounded && willBounce == false && finishedBounce == false || isGrounded && bufferJump && willBounce == false && finishedBounce == false)
                {
                    jumpPlease = true;
                    jumpTimer = 0f;
                    jumpTimerRunning = true;
                    canSlam = false;
                    bouncing = false;
                    hover = false;
                    keepJumpingPlease = false;
                    bufferJump = false;
                    StartCoroutine(Hover());
                }
                else if (isGrounded && willBounce == true)
                {
                    print("Boing!");
                    bouncePlease = true;
                    willBounce = false;
                    bouncing = true;
                    finishedBounce = true;
                }

                else if (Input.GetMouseButton(0) && !isGrounded && jumpTimerRunning && hover == true)
                {
                    keepJumpingPlease = true;
                }

                else if (!Input.GetMouseButton(0) && !isGrounded && jumpTimerRunning && hover == true)
                {
                    keepJumpingPlease = false;
                }

                if (Input.GetMouseButtonDown(0) && isAlmostGrounded && !isGrounded)
                {
                    bufferJump = true;
                }

                if (!Input.GetMouseButton(0))
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

                if (Input.GetMouseButtonDown(0) && jumpTimer == jumpTimerMax && canSlam && !isGrounded && !bouncing && !isAlmostGrounded)
                {
                    slamPlease = true;
                    willBounce = true;
                }
            }
            else if (powerup == "Flight")
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    flyPlease = true;
                }
            }

            if (powerup != "None")
            {
                powerupTimer = 0;
                if (powerupTimer < 15f)
                {
                    powerupTimer += Time.deltaTime;
                }
                else
                {
                    powerup = "None";
                    powerupTimer = 0;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (jumpPlease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPlease = false;
        }
        
        if (bouncePlease)
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
            //bounceDust.Play();
            bouncePlease = false;
            //StartCoroutine(FinishBounce());
            finishedBounce = false;
        }
        
        if (keepJumpingPlease)
        {
            rb.linearVelocity += new Vector2(rb.linearVelocity.x, 0.4f);
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

    private IEnumerator Hover()
    {
        yield return new WaitForSeconds(0.3f);
        hover = true;

    }
    
    private IEnumerator FinishBounce()
    {
        yield return new WaitForSeconds(0f);
        finishedBounce = false;
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
        gameOverScreen.SaveGame();
        powerup = "None";
    }

    public void UnDie()
    {
        dead = false;
        score.gameOver = false;
        spawner.active = true;
        spawner.ActivateObjects();
        gameUI.gameObject.SetActive(true);
       // gameOverScreen.Setup((int)(Mathf.Floor(ScoreNumber.instance.Score)));
       // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animScript.anim.enabled = true;
        céu[] allCelScript = Object.FindObjectsByType<céu>(FindObjectsSortMode.None);
        foreach (céu fundo in allCelScript)
        {
            fundo.speed = 4.5f;
        }
        chão[] allChaoScript = Object.FindObjectsByType<chão>(FindObjectsSortMode.None);
        foreach (chão montanha in allChaoScript)
        {
            montanha.speed = 3.2f;
        }
        // gameOverScreen.SaveGame();
        GameObject[] Obstaculos = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject Obstaculo in Obstaculos)
        {
            Obstaculo.SetActive(false);
        }

    }

    public void UpdateCoinText()
    {
        if (CoinCountManager.instance != null && coinText != null)
        {
            coinText.text = $" {CoinCountManager.instance.carotCount}";
        }
    }

    void UpdateSkin()
    {
        AnimatorClipInfo[] animClips = animScript.anim.GetCurrentAnimatorClipInfo(0);
        string animName = animClips[0].clip.name;

        if (PlayerSkinChanger.skin == "ballhorse")
        {
            trailRenderer.GetComponent<TrailRenderer>().startColor = new Color32(248, 87, 127, 200);
        }
        else if (PlayerSkinChanger.skin == "unicorn")
        {
            trailRenderer.GetComponent<TrailRenderer>().startColor = new Color32(0, 208, 239, 200);
        }
        else if (PlayerSkinChanger.skin == "alien")
        {
            trailRenderer.GetComponent<TrailRenderer>().startColor = new Color32(17, 197, 15, 200);
        }
        else if (PlayerSkinChanger.skin == "bubblegum")
        {
            trailRenderer.GetComponent<TrailRenderer>().startColor = new Color32(255, 0, 212, 200);
        }
        else if (PlayerSkinChanger.skin == "real")
        {
            trailRenderer.GetComponent<TrailRenderer>().startColor = new Color32(124, 94, 53, 200);
        }
    }
}