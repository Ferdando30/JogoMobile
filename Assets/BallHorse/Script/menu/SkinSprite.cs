using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    public static SkinSprite instance;
    public static string SelectedSkin;
    public List<string> skins = new();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (skins.Count == 0)
        {
            skins.Add("Padrão");
        }
    }

    public void SelectUni()
    {
        
        print("Skin Unicornio Selecionada");
        DontDestroyOnLoad(gameObject);
        SelectedSkin = "Uni";
    }

    public void SelectAlien()
    {
        
        print("Skin Alien Selecionada");
        DontDestroyOnLoad(gameObject);
        SelectedSkin = "Alien";
    }

    public void SelectPadrao()
    {
        
        print("Skin padrao Selecionada");
        DontDestroyOnLoad(gameObject);
        SelectedSkin = "Padrao";
    }

    public void SelectChic()
    {
        
        print("Skin chiclete Selecionada");
        DontDestroyOnLoad(gameObject);
        SelectedSkin = "Chic";
    }

    public void SelectReal()
    {
        
        print("Skin real Selecionada");
        DontDestroyOnLoad(gameObject);
        SelectedSkin = "Real";
    }
    public void LoadGame(GameData data)
    {
        if (data != null)
        {
            skins = data.skins;
            SelectedSkin = data.selectedSkin;
        }
    }
}
