using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MenuButtons : MonoBehaviour
{
    public Button BtnStart;
    public Button BtnStore;
    public GameObject StoreImg;
    public Button BackMenuBtn;
    public TextMeshProUGUI totalCarotsTxt;
    public TextMeshProUGUI HighScoreTxt;
    public int Price;
    public Button BuyUnicornioBtn;
    public Button BuyAlienBtn;
    public Button BuyChicleteBtn;
    public Button BuyRealBtn;
    public Button SelectUnicornioBtn;
    public Button SelectAlienBtn;
    public Button SelectPadraoBtn;
    public Button SelectChicletBtn;
    public Button SelectRealBtn;
    public Button HighScoreBtn;

    private TotalCarots totalCarots;
    private HighScore highScore;
    public SkinSprite skinSprite;
    public GameData data;

    public static bool UniComprado = false;
    public static bool AlienComprado = false;
    public static bool ChicComprado = false;
    public static bool RealComprado = false;

    public GameObject TutorasImg;
    public Button TutorasBtn;
    public bool tutorasAberto;
    public Slider musicSlider;
    public TextMeshProUGUI PriceTxt;

    void Start()
    {
        totalCarots = TotalCarots.instance;
        highScore = HighScore.instance;
        skinSprite = SkinSprite.instance;

        data = SaveSystem.Load();
        totalCarots.LoadGame(data);
        highScore.LoadGame(data);
        skinSprite.LoadGame(data);

        BtnStore.gameObject.SetActive(true);
        BtnStart.gameObject.SetActive(true);
        HighScoreBtn.gameObject.SetActive(true);
        BackMenuBtn.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        totalCarotsTxt.enabled = false;
        HighScoreTxt.enabled = false;
        BuyUnicornioBtn.gameObject.SetActive(false);
        BuyAlienBtn.gameObject.SetActive(false);
        BuyChicleteBtn.gameObject.SetActive(false);
        BuyRealBtn.gameObject.SetActive(false);
        SelectUnicornioBtn.gameObject.SetActive(false);
        SelectAlienBtn.gameObject.SetActive(false);
        SelectPadraoBtn.gameObject.SetActive(false);
        SelectChicletBtn.gameObject.SetActive(false);
        SelectRealBtn.gameObject.SetActive(false);
        CarrotTextUpdate();
        HighScoreTxtUpdate();
        TutorasImg.SetActive(false);
        TutorasBtn.gameObject.SetActive(false);
        tutorasAberto = false;
        musicSlider.gameObject.SetActive(false);
        PriceTxt.enabled = false;

        if (skinSprite.skins.Contains("Uni"))
        {
            UniComprado = true;
        }
        if (skinSprite.skins.Contains("Alien"))
        {
            AlienComprado = true;
        }
        if (skinSprite.skins.Contains("Chic"))
        {
            ChicComprado = true;
        }
        if (skinSprite.skins.Contains("Real"))
        {
            RealComprado = true;
        }
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
        totalCarotsTxt.enabled = true;
        SelectPadraoBtn.gameObject.SetActive(true);
        PriceTxt.enabled = true;
        if (UniComprado == true)
        {
            SelectUnicornioBtn.gameObject.SetActive(true);
        }
        else
        {
            BuyUnicornioBtn.gameObject.SetActive(true);
        }

        if(AlienComprado == true)
        {
            SelectAlienBtn.gameObject.SetActive(true);
        }
        else
        {
            BuyAlienBtn.gameObject.SetActive(true);
        }

        if (ChicComprado == true) 
        {
           SelectChicletBtn.gameObject.SetActive(true);
        }
        else
        {
            BuyChicleteBtn.gameObject.SetActive(true);
        }

        if (RealComprado == true) 
        { 
            SelectRealBtn.gameObject.SetActive(true);
        }
        else
        {
            BuyRealBtn.gameObject.SetActive(true);
        }
    }

    public void BackBtn()
    {
        if(tutorasAberto == true)
        {
            TutorasBtn.gameObject.SetActive(true);
            TutorasImg.SetActive(false);
            tutorasAberto = false;
            musicSlider.gameObject.SetActive(true);
        }
        else
        {
            BtnStore.gameObject.SetActive(true);
            BtnStart.gameObject.SetActive(true);
            HighScoreBtn.gameObject.SetActive(true);
            BackMenuBtn.gameObject.SetActive(false);
            StoreImg.SetActive(false);
            totalCarotsTxt.enabled = false;
            HighScoreTxt.enabled = false;
            BuyUnicornioBtn.gameObject.SetActive(false);
            BuyAlienBtn.gameObject.SetActive(false);
            BuyChicleteBtn.gameObject.SetActive(false);
            BuyRealBtn.gameObject.SetActive(false);
            SelectUnicornioBtn.gameObject.SetActive(false);
            SelectAlienBtn.gameObject.SetActive(false);
            SelectPadraoBtn.gameObject.SetActive(false);
            SelectChicletBtn.gameObject.SetActive(false);
            SelectRealBtn.gameObject.SetActive(false);
            TutorasBtn.gameObject.SetActive(false);
            musicSlider.gameObject.SetActive(false);
            PriceTxt.enabled = false;
        }
    }

    public void BuyUnicornio()
    {
        BuySkin(BuyUnicornioBtn, SelectUnicornioBtn);
        UniComprado = true;
        skinSprite.skins.Add("Uni");
        SaveSystem.Save(totalCarots, highScore, skinSprite);
    }

    public void BuyAlien()
    {
        BuySkin(BuyAlienBtn, SelectAlienBtn);
        AlienComprado = true;
        skinSprite.skins.Add("Alien");
        SaveSystem.Save(totalCarots, highScore, skinSprite);
    }

    public void BuyChiclete()
    {
        BuySkin(BuyChicleteBtn, SelectChicletBtn);
        ChicComprado = true;
        skinSprite.skins.Add("Chic");
        SaveSystem.Save(totalCarots, highScore, skinSprite);
    }

    public void BuyReal()
    {
        BuySkin(BuyRealBtn, SelectRealBtn);
        RealComprado = true;
        skinSprite.skins.Add("Real");
        SaveSystem.Save(totalCarots, highScore, skinSprite);
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
        TutorasBtn.gameObject.SetActive(true);
        musicSlider.gameObject.SetActive(true);
    }

    //Apartir daqui estou colocando um codigo que não tem haver com os botões, mas é melhor colocar aqui para nn criar script extra pra coisa pequena

    public void CarrotTextUpdate()
    {
        if (TotalCarots.instance != null && totalCarotsTxt != null)
        {
            totalCarotsTxt.text = $"Carrots: {TotalCarots.instance.CarotsTotal}";
        }
    }

    public void HighScoreTxtUpdate()
    {
        HighScoreTxt.text = $"High Score: {Mathf.Floor(HighScore.instance.HighScoreCount - 1)}";
    }

    public void SaveGame()
    {
        SaveSystem.Save(totalCarots, highScore, skinSprite);
        print("Jogo salvo.");
    }

    public void Tutorial()
    {
       TutorasImg.SetActive(true);
       TutorasBtn.gameObject.SetActive(false);
        tutorasAberto = true;
        musicSlider.gameObject.SetActive(false);
    }
}
