using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    public static bool isPadrao;
    public static bool isUni;
    public static bool isAlien;
    public static bool isChiclete;
    public static bool isReal;

    public void SelectUni()
    {
        isPadrao = false;
        isUni = true;
        isAlien = false;
        isChiclete = false;
        isReal = false;
        print("Skin Unicornio Selecionada");
        DontDestroyOnLoad(gameObject);
    }

    public void SelectAlien()
    {
        isPadrao = false;
        isUni = false;
        isAlien = true;
        isChiclete = false;
        isReal = false;
        print("Skin Alien Selecionada");
        DontDestroyOnLoad(gameObject);
    }

    public void SelectPadrao()
    {
        isPadrao = true;
        isUni = false;
        isAlien = false;
        isChiclete = false;
        isReal = false;
        print("Skin padrao Selecionada");
        DontDestroyOnLoad(gameObject);
    }

    public void SelectChic()
    {
        isPadrao = false;
        isUni = false;
        isAlien = false;
        isChiclete = true;
        isReal = false;
        print("Skin chiclete Selecionada");
        DontDestroyOnLoad(gameObject);
    }

    public void SelectReal()
    {
        isPadrao = false;
        isUni = false;
        isAlien = false;
        isChiclete = false;
        isReal = true;
        print("Skin real Selecionada");
        DontDestroyOnLoad(gameObject);
    }
}
