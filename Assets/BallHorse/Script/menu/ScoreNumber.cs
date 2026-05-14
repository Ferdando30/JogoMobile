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

        ValorX = 500;
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

    public void Reset()
    {
        ScoreNumber.instance.ValorX = 500;
        ScoreNumber.instance.Dia = true;
        ScoreNumber.instance.Tarde = false;
        ScoreNumber.instance.Noite = false;
    }

    public void MudarSpirte()
    {
        GameObject[] CeuTag = GameObject.FindGameObjectsWithTag("Ceu");
        GameObject[] NuvemTag = GameObject.FindGameObjectsWithTag("Nuvem");

        if (Score > ValorX)
        {
            bool todosMudaram = true;

            Sprite novoSpriteCeu = null;
            Sprite novoSpriteNuvem = null;

            if (Dia == true && Tarde == false && Noite == false)
            {
                novoSpriteCeu = CeuTarde;
                novoSpriteNuvem = NuvemTarde;
            }
            else if (Dia == false && Tarde == true && Noite == false)
            {
                novoSpriteCeu = CeuNoite;
                novoSpriteNuvem = NuvemNoite;
            }
            else if (Dia == false && Tarde == false && Noite == true)
            {
                novoSpriteCeu = CeuDia;
                novoSpriteNuvem = NuvemDia;
            }

            foreach (GameObject obj in CeuTag)
            {
                SpriteCeu = obj.GetComponent<SpriteRenderer>();

                if (SpriteCeu.sprite != novoSpriteCeu)
                {
                    if (obj.transform.position.x < -21.29)
                    {
                        SpriteCeu.sprite = novoSpriteCeu;
                    }
                    else
                    {
                        todosMudaram = false;
                    }
                }
            }

            foreach (GameObject obj in NuvemTag)
            {
                SpriteNuvem = obj.GetComponent<SpriteRenderer>();

                if (SpriteNuvem.sprite != novoSpriteNuvem)
                {
                    if (obj.transform.position.x < -21.51)
                    {
                        SpriteNuvem.sprite = novoSpriteNuvem;
                    }
                    else
                    {
                        todosMudaram = false;
                    }
                }
            }

            if (todosMudaram == true)
            {
                if (Dia == true && Tarde == false && Noite == false)
                {
                    Dia = false;
                    Tarde = true;
                    Noite = false;
                }
                else if (Dia == false && Tarde == true && Noite == false)
                {
                    Dia = false;
                    Tarde = false;
                    Noite = true;
                }
                else if (Dia == false && Tarde == false && Noite == true)
                {
                    Dia = true;
                    Tarde = false;
                    Noite = false;
                }

                ValorX = ValorX + 650;
            }
        }
    }
}
