using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Adapter Klasse zwischen PlayerGUI und einem Einzelnen Button
/// </summary>
public class AbilityButton : MonoBehaviour
{
    public Image ForegroundImage, BackgroundImage, ButtonBackground;
   [HideInInspector] public int index = 0;

    public void SetCooldown01(float cooldown01)
    {
        ForegroundImage.fillAmount = cooldown01;
        if(cooldown01 < 1f)
        {
            ButtonBackground.color = Color.gray;
            
        }
        else
        {
            ButtonBackground.color = Color.white;
        }
    }

    public void SetIcon(Sprite icon)
    {
        ForegroundImage.sprite = icon;
        BackgroundImage.sprite = icon;
    }

    public void SetActive()
    {

    }
}
