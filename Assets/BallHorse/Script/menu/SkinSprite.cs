using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    
    public static bool isUni;
    public static bool isAlien;

    public void SelectUni()
    {
        isUni = true;
        isAlien = false;
        print("Skin Unicornio Selecionada");
        DontDestroyOnLoad(gameObject);
    }

    public void SelectAlien()
    {
        isUni = false;
        isAlien = true;
        print("Skin Alien Selecionada");
        DontDestroyOnLoad(gameObject);
    }
}
