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
    public GameObject OptionImg;
    public Button BackMenuBtn;
    public TextMeshProUGUI totalCarotsTxt;
    public TextMeshProUGUI HighScoreTxt;
   // public int Price;
    public Button BuyUnicornioBtn;
    public Button BuyAlienBtn;
    public Button BuyChicleteBtn;
    public Button BuyRealBtn;
    public Button SelectUnicornioBtn;
    public Button SelectAlienBtn;
    public Button SelectPadraoBtn;
    public Button SelectChicletBtn;
    public Button SelectRealBtn;
    public Button BuyMoonBtn;
    public Button SelectMoonBtn;
    public Button BuyCandyBtn;
    public Button SelectCandyBtn;
    public Button HighScoreBtn;
    public Button BackStore;
    public Button SelectColina;

    private TotalCarots totalCarots;
    private HighScore highScore;
    public SkinSprite skinSprite;
    public GameData data;

    public static bool UniComprado = false;
    public static bool AlienComprado = false;
    public static bool ChicComprado = false;
    public static bool RealComprado = false;
    public static bool LuaComprado = false;
    public static bool DoceComprado = false;

    public GameObject TutorasImg;
    public Button TutorasBtn;
    public bool tutorasAberto;
    public Slider musicSlider;
    public GameObject TextHolder;
    public GameObject TextHolderTwo;

    public GameObject CreditsHolder;
    public bool CreditosAberto;
    public Button CreditosBtn;

    public int paginas;
    public Button paginaBtn;

    private bool compreiCerto;
   

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
        BackStore.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        OptionImg.SetActive(false);
        totalCarotsTxt.enabled = false;
        HighScoreTxt.enabled = false;
        BuyUnicornioBtn.gameObject.SetActive(false);
        BuyAlienBtn.gameObject.SetActive(false);
        BuyChicleteBtn.gameObject.SetActive(false);
        BuyRealBtn.gameObject.SetActive(false);
        BuyMoonBtn.gameObject.SetActive(false);
        BuyCandyBtn.gameObject.SetActive(false);
        SelectUnicornioBtn.gameObject.SetActive(false);
        SelectAlienBtn.gameObject.SetActive(false);
        SelectPadraoBtn.gameObject.SetActive(false);
        SelectChicletBtn.gameObject.SetActive(false);
        SelectRealBtn.gameObject.SetActive(false);
        SelectMoonBtn.gameObject.SetActive(false);
        SelectCandyBtn.gameObject.SetActive(false);
        SelectColina.gameObject.SetActive(false);
        CarrotTextUpdate();
        HighScoreTxtUpdate();
        TutorasImg.SetActive(false);
        TextHolder.SetActive(false);
        TextHolderTwo.SetActive(false);
        TutorasBtn.gameObject.SetActive(true);
        tutorasAberto = false;
        musicSlider.gameObject.SetActive(false);
        CreditsHolder.SetActive(false);
        CreditosAberto = false;
        CreditosBtn.gameObject.SetActive(false);
        paginaBtn.gameObject.SetActive(false);
        

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
        if (skinSprite.sceneries.Contains("Lua"))
        {
            LuaComprado = true;
        }
        if (skinSprite.sceneries.Contains("Doce"))
        {
            DoceComprado = true;
        }
        paginas = 1;
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
        TutorasBtn.gameObject.SetActive(false);
        paginaBtn.gameObject.SetActive(true);
        BackStore.gameObject.SetActive(true);
        StoreImg.SetActive(true);
        totalCarotsTxt.enabled = true;

        if (paginas == 1)
        {
            SelectPadraoBtn.gameObject.SetActive(true);
            TextHolder.SetActive(true);
            TextHolderTwo.SetActive(false);
            SelectColina.gameObject.SetActive(false);

            if (UniComprado == true)
            {
                SelectUnicornioBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyUnicornioBtn.gameObject.SetActive(true);
            }

            if (AlienComprado == true)
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
            if (LuaComprado == true)
            {
                SelectMoonBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyMoonBtn.gameObject.SetActive(false);
            }
            if (DoceComprado == true)
            {
                SelectCandyBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyCandyBtn.gameObject.SetActive(false);
            }
        }

        else if(paginas == 2)
        {
            SelectPadraoBtn.gameObject.SetActive(false);
            TextHolder.SetActive(false);
            TextHolderTwo.SetActive(true);
            SelectColina.gameObject.SetActive(true);

            if (UniComprado == true)
            {
                SelectUnicornioBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyUnicornioBtn.gameObject.SetActive(false);
            }

            if (AlienComprado == true)
            {
                SelectAlienBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyAlienBtn.gameObject.SetActive(false);
            }

            if (ChicComprado == true)
            {
                SelectChicletBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyChicleteBtn.gameObject.SetActive(false);
            }

            if (RealComprado == true)
            {
                SelectRealBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyRealBtn.gameObject.SetActive(false);
            }
            if (LuaComprado == true)
            {
                SelectMoonBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyMoonBtn.gameObject.SetActive(true);
            }
            if (DoceComprado == true)
            {
                SelectCandyBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyCandyBtn.gameObject.SetActive(true);
            }
        }
    }

    public void BackBtn()
    {
        if(tutorasAberto == true)
        {
            TutorasBtn.gameObject.SetActive(true);
            TutorasImg.SetActive(false);
            tutorasAberto = false;
            StoreImg.SetActive(false);
            OptionImg.SetActive(false);
            BackMenuBtn.gameObject.SetActive(false);
            BackStore.gameObject.SetActive(false);
            BtnStore.gameObject.SetActive(true);
            BtnStart.gameObject.SetActive(true);
            HighScoreBtn.gameObject.SetActive(true);
        }
        else if(CreditosAberto == true)
        {
            musicSlider.gameObject.SetActive(true);
            HighScoreTxt.enabled = true;
            CreditosAberto = false;
            CreditsHolder.SetActive(false);
            CreditosBtn.gameObject.SetActive(true);
        }
        else
        {
            BtnStore.gameObject.SetActive(true);
            BtnStart.gameObject.SetActive(true);
            HighScoreBtn.gameObject.SetActive(true);
            BackMenuBtn.gameObject.SetActive(false);
            BackStore.gameObject.SetActive(false);
            StoreImg.SetActive(false);
            OptionImg.SetActive(false);
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
            TutorasBtn.gameObject.SetActive(true);
            musicSlider.gameObject.SetActive(false);
            SelectMoonBtn.gameObject.SetActive(false);
            SelectCandyBtn.gameObject.SetActive(false);
            BuyMoonBtn.gameObject.SetActive(false);
            BuyCandyBtn.gameObject.SetActive(false);
            TextHolder.SetActive(false);
            SelectColina.gameObject.SetActive(false);
            CreditosBtn.gameObject.SetActive(false);
            paginaBtn.gameObject.SetActive(false);
            TextHolderTwo.SetActive(false);
        }
    }

    public void BuyUnicornio()
    {
        BuySkin(BuyUnicornioBtn, SelectUnicornioBtn, 600);
        if(compreiCerto == true)
        {
            UniComprado = true;
            skinSprite.skins.Add("Uni");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
    }

    public void BuyAlien()
    {
        BuySkin(BuyAlienBtn, SelectAlienBtn, 600);
        if (compreiCerto == true)
        {
            AlienComprado = true;
            skinSprite.skins.Add("Alien");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
            
    }

    public void BuyChiclete()
    {
        BuySkin(BuyChicleteBtn, SelectChicletBtn, 400);
        if (compreiCerto == true)
        {
            ChicComprado = true;
            skinSprite.skins.Add("Chic");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
            
    }

    public void BuyReal()
    {
        BuySkin(BuyRealBtn, SelectRealBtn, 1000);
        if (compreiCerto == true)
        {
            RealComprado = true;
            skinSprite.skins.Add("Real");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
     
    }

    public void BuyMoon()
    {
        BuySkin(BuyMoonBtn, SelectMoonBtn, 2500);
        if (compreiCerto == true)
        {
            LuaComprado = true;
            skinSprite.sceneries.Add("Lua");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
            
    }

    public void BuyCandy()
    {
        BuySkin(BuyCandyBtn, SelectCandyBtn, 2500);
        if (compreiCerto == true)
        {
            DoceComprado = true;
            skinSprite.sceneries.Add("Doce");
            SaveSystem.Save(totalCarots, highScore, skinSprite);
        }
            
    }

    private void BuySkin(Button buyButton, Button selectButton, int Price)
    {
        if (TotalCarots.instance.CarotsTotal >= Price)
        {
            TotalCarots.instance.CarotsTotal -= Price;
            CarrotTextUpdate();
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            compreiCerto = true;
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
        OptionImg.SetActive(true);
        HighScoreTxt.enabled = true;
        TutorasBtn.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(true);
        TutorasBtn.gameObject.SetActive(false);
        CreditosBtn.gameObject.SetActive(true);
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
        OptionImg.SetActive(true);
        BackMenuBtn.gameObject.SetActive(true);
        BtnStore.gameObject.SetActive(false);
        BtnStart.gameObject.SetActive(false);
        HighScoreBtn.gameObject.SetActive(false);
    }

    public void Creditos()
    {
        musicSlider.gameObject.SetActive(false);
        HighScoreTxt.enabled = false;
        CreditosAberto = true;
        CreditsHolder.SetActive(true);
        CreditosBtn.gameObject.SetActive(false);
    }

    public void PassarPagina()
    {
        if (paginas == 2)
        {
            SelectPadraoBtn.gameObject.SetActive(true);
            TextHolder.SetActive(true);
            TextHolderTwo.SetActive(false);
            SelectColina.gameObject.SetActive(false);
            paginas = 1;

            if (UniComprado == true)
            {
                SelectUnicornioBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyUnicornioBtn.gameObject.SetActive(true);
            }

            if (AlienComprado == true)
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
            if (LuaComprado == true)
            {
                SelectMoonBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyMoonBtn.gameObject.SetActive(false);
            }
            if (DoceComprado == true)
            {
                SelectCandyBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyCandyBtn.gameObject.SetActive(false);
            }
        }

        else if (paginas == 1)
        {
            SelectPadraoBtn.gameObject.SetActive(false);
            TextHolder.SetActive(false);
            TextHolderTwo.SetActive(true);
            SelectColina.gameObject.SetActive(true);
            paginas = 2;

            if (UniComprado == true)
            {
                SelectUnicornioBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyUnicornioBtn.gameObject.SetActive(false);
            }

            if (AlienComprado == true)
            {
                SelectAlienBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyAlienBtn.gameObject.SetActive(false);
            }

            if (ChicComprado == true)
            {
                SelectChicletBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyChicleteBtn.gameObject.SetActive(false);
            }

            if (RealComprado == true)
            {
                SelectRealBtn.gameObject.SetActive(false);
            }
            else
            {
                BuyRealBtn.gameObject.SetActive(false);
            }
            if (LuaComprado == true)
            {
                SelectMoonBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyMoonBtn.gameObject.SetActive(true);
            }
            if (DoceComprado == true)
            {
                SelectCandyBtn.gameObject.SetActive(true);
            }
            else
            {
                BuyCandyBtn.gameObject.SetActive(true);
            }
        }
    }
}
