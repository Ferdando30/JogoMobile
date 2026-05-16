using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuButtons : MonoBehaviour
{
    public Button BtnStart;
    public Button BtnStore;
    public GameObject StoreImg;
    public Button BackMenuBtn;
    public TextMeshProUGUI totalCarots;
    public TextMeshProUGUI HighScoreTxt;
    public int Price;
    public Button BuyUnicornioBtn;
    public Button BuyAlienBtn;
    public Button SelectUnicornioBtn;
    public Button SelectAlienBtn;
    public Button HighScoreBtn;

    
    void Awake()
    {
        BtnStore.gameObject.SetActive(true);
        BtnStart.gameObject.SetActive(true);
        HighScoreBtn.gameObject.SetActive(true);
        BackMenuBtn.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        totalCarots.enabled = false;
        HighScoreTxt.enabled = false;
        BuyUnicornioBtn.gameObject.SetActive(false);
        BuyAlienBtn.gameObject.SetActive(false);
        SelectUnicornioBtn.gameObject.SetActive(false);
        SelectAlienBtn.gameObject.SetActive(false);
        CarrotTextUpdate();
        HighScoreTxtUpdate();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Ballhorse");
    }

    public void StoreBtn()
    {
        BtnStore.gameObject.SetActive(false);
        BtnStart.gameObject.SetActive(false);
        HighScoreBtn.gameObject.SetActive(false);
        BackMenuBtn.gameObject.SetActive(true);
        StoreImg.SetActive(true);
        totalCarots.enabled = true;
        BuyUnicornioBtn.gameObject.SetActive(true);
        BuyAlienBtn.gameObject.SetActive(true);
    }

    public void BackBtn()
    {
        BtnStore.gameObject.SetActive(true);
        BtnStart.gameObject.SetActive(true);
        HighScoreBtn.gameObject.SetActive(true);
        BackMenuBtn.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        totalCarots.enabled = false;
        HighScoreTxt.enabled = false;
        BuyUnicornioBtn.gameObject.SetActive(false);
        BuyAlienBtn.gameObject.SetActive(false);
        SelectUnicornioBtn.gameObject.SetActive(false);
        SelectAlienBtn.gameObject.SetActive(false);
    }

    public void BuyUnicornio()
    {
        BuySkin(BuyUnicornioBtn, SelectUnicornioBtn);
    }

    public void BuyAlien()
    {
        BuySkin(BuyAlienBtn, SelectAlienBtn);
    }

    

    private void BuySkin(Button buyButton, Button selectButton)
    {
        if (TotalCarots.instance.CarotsTotal >= Price)
        {
            TotalCarots.instance.CarotsTotal -= Price;
            CarrotTextUpdate();
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Muito caro chefe, fica pra proxima");
        }
    }
    public void HighScoreOpen()
    {
        BtnStore.gameObject.SetActive(false);
        BtnStart.gameObject.SetActive(false);
        HighScoreBtn.gameObject.SetActive(false);
        BackMenuBtn.gameObject.SetActive(true);
        StoreImg.SetActive(true);
        HighScoreTxt.enabled = true;
    }

    //Apartir daqui estou colocando um codigo que não tem haver com os botões, mas é melhor colocar aqui para nn criar script extra pra coisa pequena

    public void CarrotTextUpdate()
    {
        if (TotalCarots.instance != null && totalCarots != null)
        {
            totalCarots.text = $"Carrots: {TotalCarots.instance.CarotsTotal}";
        }
    }

    public void HighScoreTxtUpdate()
    {
        HighScoreTxt.text = $"High Score: {Mathf.Floor(HighScore.instance.HighScoreCount - 1)}";
    }
}
