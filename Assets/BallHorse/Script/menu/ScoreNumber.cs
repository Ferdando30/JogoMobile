using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreNumber : MonoBehaviour
{
    public float Score;
    public float moveMultiplier;
    public static ScoreNumber instance;
    public bool Dia;
    public bool Tarde;
    public bool Noite;
    public int tickTime;

    private SpriteRenderer SpriteCeu;
    private SpriteRenderer SpriteNuvem;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        tickTime = 500;
        Dia = true;
        Tarde = false;
        Noite = false;
    }

    private void Update()
    {

        if ((Score <= 99 && moveMultiplier != 1.0f)|| SceneManager.GetActiveScene().name == "Menu")
        {
            moveMultiplier = 1.0f;
        }
        else if (Score >= 100 && moveMultiplier != 1.1f)
        {
            moveMultiplier = 1.1f;
        }
        
        if (Score > tickTime)
        {
            MudarSpirte();
        }
    }

    public void ResetValues()
    {
        tickTime = 500;
        Dia = true;
        Tarde = false;
        Noite = false;
        Score = 0;
        moveMultiplier = 1.0f;
    }

    public void MudarSpirte()
    {
        GameObject[] CeuTag = GameObject.FindGameObjectsWithTag("Ceu");
        foreach (GameObject obj in CeuTag)
        {
            obj.GetComponent<céu>().StartCoroutine("PlayFade");
        }

        GameObject[] NuvemTag = GameObject.FindGameObjectsWithTag("Nuvem");
        foreach (GameObject obj in NuvemTag)
        {
            obj.GetComponent<céu>().StartCoroutine("PlayFade");
        }

        if (Dia == true)
        {
            Dia = false;
            Tarde = true;
            Noite = false;
        }
        else if (Tarde == true)
        {
            Dia = false;
            Tarde = false;
            Noite = true;
        }
        else if (Noite == true)
        {
            Dia = true;
            Tarde = false;
            Noite = false;
        }
        
        tickTime += 650;
    }
}
