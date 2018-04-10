using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGUI : MonoBehaviour
{

    public Image HealthBar, ManaBar, RipImage;
    public void SetHealth(int health)
    {
        HealthBar.fillAmount =  (float) health / 100f;
        if (health <= 0)
        {
            RipImage.enabled = true;
        }
        
    }

    public void SetMana(int Mana)
    {
        ManaBar.fillAmount = (float)Mana / 100f;
    }
}
