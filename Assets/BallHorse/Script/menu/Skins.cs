using UnityEngine;

public class Skins : MonoBehaviour
{
    public static Skins instance;
    public bool Unicornio;
    public bool Alien;
    private void Awake()
    {
        
        instance = this;
       
    }
}
