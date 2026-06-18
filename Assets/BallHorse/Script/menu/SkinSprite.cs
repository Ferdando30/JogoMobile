using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    public static SkinSprite instance;
    public static string SelectedSkin;
    public List<string> skins = new();
    public List<string> sceneries = new();

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

        if (sceneries.Count == 0)
        {
            sceneries.Add("Padrão");
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
            if (data.skins != null)
            {
                skins = data.skins;
            }
            if (data.selectedSkin != null)
            {
                SelectedSkin = data.selectedSkin;
            }
            if (data.sceneries != null)
            {
                sceneries = data.sceneries;
            }
        }
    }
}
