using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public Player playerScript;
    public Image myImage;
    void Update()
    {
        if(playerScript.TimesCanRevive == 1)
        {
            myImage.color = new Color32(255, 255, 255, 255);
            
        }

        else if(playerScript.TimesCanRevive == 0)
        {
            myImage.color = new Color32(99, 99, 99, 255);
            
        }
    }
}
