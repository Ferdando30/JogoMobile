using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    public const string DefaultSkin = "Padrao";
    public const string DefaultScenery = "Padrão";

    public static SkinSprite instance;
    public static string SelectedSkin = DefaultSkin;
    public static string SelectedScenery = DefaultScenery;
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
        EnsureDefaults();
        EnsureDefaultUnlocks();
    }

    public static void EnsureDefaults()
    {
        if (string.IsNullOrEmpty(SelectedSkin))
        {
            SelectedSkin = DefaultSkin;
        }

        if (string.IsNullOrEmpty(SelectedScenery))
        {
            SelectedScenery = DefaultScenery;
        }
    }

    private void EnsureDefaultUnlocks()
    {
        if (!skins.Contains(DefaultSkin))
        {
            skins.Add(DefaultSkin);
        }

        if (!sceneries.Contains(DefaultScenery))
        {
            sceneries.Add(DefaultScenery);
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
        SelectedSkin = DefaultSkin;
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

    public void SelectScenePadrao()
    {
        DontDestroyOnLoad(gameObject);
        SelectedScenery = DefaultScenery;
    }

    public void SelectSceneMoon()
    {
        DontDestroyOnLoad(gameObject);
        SelectedScenery = "Lua";
    }

    public void SelectSceneCandy()
    {
        DontDestroyOnLoad(gameObject);
        SelectedScenery = "Doce";
    }

    public void LoadGame(GameData data)
    {
        if (data != null)
        {
            if (data.skins != null)
            {
                skins = data.skins;
            }
            if (!string.IsNullOrEmpty(data.selectedSkin))
            {
                SelectedSkin = data.selectedSkin;
            }
            if (data.sceneries != null)
            {
                sceneries = data.sceneries;
            }
            if (!string.IsNullOrEmpty(data.selectedScenery))
            {
                SelectedScenery = data.selectedScenery;
            }
        }

        EnsureDefaults();
        EnsureDefaultUnlocks();
    }
}
