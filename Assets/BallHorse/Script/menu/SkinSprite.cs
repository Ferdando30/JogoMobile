using UnityEngine;

public class SkinSprite : MonoBehaviour
{
   
    public static string SelectedSkin;

    private void Awake()
    {
        SelectedSkin = "Padrao";
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
}
