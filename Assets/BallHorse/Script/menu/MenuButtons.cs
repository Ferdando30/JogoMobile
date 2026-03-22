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
    public int Price;
    public Button BuyBtn;
    void Awake()
    {
        BtnStore.gameObject.SetActive(true);
        BtnStart.gameObject.SetActive(true);
        BackMenuBtn.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        totalCarots.enabled = false;
        BuyBtn.gameObject.SetActive(false);
        CarrotTextUpdate();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Ballhorse");
    }

    public void StoreBtn()
    {
        BtnStore.gameObject.SetActive(false);
        BtnStart.gameObject.SetActive(false);
        BackMenuBtn.gameObject.SetActive(true);
        StoreImg.SetActive(true);
        totalCarots.enabled = true;
        BuyBtn.gameObject.SetActive(true);
    }

    public void BackBtn()
    {
        BtnStore.gameObject.SetActive(true);
        BtnStart.gameObject.SetActive(true);
        BackMenuBtn.gameObject.SetActive(false);
        StoreImg.SetActive(false);
        totalCarots.enabled = false;
        BuyBtn.gameObject.SetActive(false);
    }

    public void BuyTest()
    {
        if(TotalCarots.instance.CarotsTotal >= Price)
        {
            TotalCarots.instance.CarotsTotal = TotalCarots.instance.CarotsTotal - Price;
            CarrotTextUpdate();
        }
        else
        {
            Debug.Log("Muito caro chefe, fica pra proxima");
        }
    }

    //Apartir daqui estou colocando um codigo que não tem haver com os botões, mas é melhor colocar aqui para nn criar script extra pra coisa pequena

    public void CarrotTextUpdate()
    {
        if (TotalCarots.instance != null && totalCarots != null)
        {
            totalCarots.text = $"Carrots: {TotalCarots.instance.CarotsTotal}";
        }
    }
}
