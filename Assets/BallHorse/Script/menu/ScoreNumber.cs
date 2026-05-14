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
    public int ValorX;
    public Sprite CeuDia;
    public Sprite CeuTarde;
    public Sprite CeuNoite;
    public Sprite NuvemDia;
    public Sprite NuvemTarde;
    public Sprite NuvemNoite;
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

        ValorX = 200;
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
        MudarSpirte();
    }

    public void MudarSpirte()
    {
        if(Score > ValorX)
        {
            if (Dia == true && Tarde == false && Noite == false)
            {
                GameObject[] CeuTag = GameObject.FindGameObjectsWithTag("Ceu");
                foreach(GameObject obj in CeuTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = CeuTarde;
                }
                GameObject[] NuvemTag = GameObject.FindGameObjectsWithTag("Nuvem");
                foreach (GameObject obj in NuvemTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = NuvemTarde;
                }
                Dia = false;
                Tarde = true;
                Noite = false;
            }
            else if (Dia == false && Tarde == true && Noite == false)
            {
                GameObject[] CeuTag = GameObject.FindGameObjectsWithTag("Ceu");
                foreach (GameObject obj in CeuTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = CeuNoite;
                }
                GameObject[] NuvemTag = GameObject.FindGameObjectsWithTag("Nuvem");
                foreach (GameObject obj in NuvemTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = NuvemNoite;
                }
                //ValorX = ValorX + 200;
                Dia = false;
                Tarde = false;
                Noite = true;
            }
            else if (Dia == false && Tarde == false && Noite == true)
            {
                GameObject[] CeuTag = GameObject.FindGameObjectsWithTag("Ceu");
                foreach (GameObject obj in CeuTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = CeuDia;
                }
                GameObject[] NuvemTag = GameObject.FindGameObjectsWithTag("Nuvem");
                foreach (GameObject obj in NuvemTag)
                {
                    SpriteCeu = obj.GetComponent<SpriteRenderer>();
                    SpriteCeu.sprite = NuvemDia;
                }
               // ValorX = ValorX + 200;
                Dia = true;
                Tarde = false;
                Noite = false;
            }
            ValorX = ValorX + 200;
        }
    }
}
