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
    public float tickTime;
    public float ogTickTime;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        ogTickTime = 500;
        tickTime = 500;
        Dia = true;
        Tarde = false;
        Noite = false;
    }

    private void Update()
    {

        if (Score <= 99 && moveMultiplier < 1.0f)
        {
            moveMultiplier = 1.0f;
        }
        else if (Score >= 100 && moveMultiplier < 1.1f)
        {
            moveMultiplier = 1.1f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 300 && moveMultiplier < 1.2f)
        {
            moveMultiplier = 1.2f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 550 && moveMultiplier < 1.3f)
        {
            moveMultiplier = 1.3f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 700 && moveMultiplier < 1.4f)
        {
            moveMultiplier = 1.4f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 960 && moveMultiplier < 1.5f)
        {
            moveMultiplier = 1.5f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 1050 && moveMultiplier < 1.6f)
        {
            moveMultiplier = 1.6f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 1300 && moveMultiplier < 1.7f)
        {
            moveMultiplier = 1.7f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 1550 && moveMultiplier < 1.8f)
        {
            moveMultiplier = 1.8f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 1800 && moveMultiplier < 1.9f)
        {
            moveMultiplier = 1.9f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 2050 && moveMultiplier < 2f)
        {
            moveMultiplier = 2f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 2250 && moveMultiplier < 2.1f)
        {
            moveMultiplier = 2.1f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 2500 && moveMultiplier < 2.2f)
        {
            moveMultiplier = 2.2f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 2700 && moveMultiplier < 2.3f)
        {
            moveMultiplier = 2.3f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 2950 && moveMultiplier < 2.4f)
        {
            moveMultiplier = 2.4f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 3200 && moveMultiplier < 2.5f)
        {
            moveMultiplier = 2.5f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 3500 && moveMultiplier < 2.6f)
        {
            moveMultiplier = 2.6f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 3750 && moveMultiplier < 2.7f)
        {
            moveMultiplier = 2.7f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 4000 && moveMultiplier < 2.8f)
        {
            moveMultiplier = 2.8f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 4250 && moveMultiplier < 2.9f)
        {
            moveMultiplier = 2.9f;
            tickTime = ogTickTime * moveMultiplier;
        }
        else if (Score >= 4500 && moveMultiplier < 3f)
        {
            moveMultiplier = 3f;
            tickTime = ogTickTime * moveMultiplier;
        }

        if (Score > tickTime)
        {
            MudarSpirte();
        }
    }

    public void ResetValues()
    {
        ogTickTime = 500;
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

        ogTickTime += 650;
        tickTime = ogTickTime * moveMultiplier;
    }
}
