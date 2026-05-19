using UnityEngine;

public class SkinSprite : MonoBehaviour
{
    public static Sprite SkinHolder;
    public static bool isUni;
    [SerializeField] private Sprite UniSkin;
    
    private void Awake()
    {
        
    }

    public void SelectUni()
    {
        SkinHolder = UniSkin;
        isUni = true;
        print("Skin Unicornio Selecionada");
        DontDestroyOnLoad(gameObject);
    }
}
