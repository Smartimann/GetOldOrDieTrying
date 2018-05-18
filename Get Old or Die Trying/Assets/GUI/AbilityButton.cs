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
    public Text TotalUsesText;
   [HideInInspector] public int index = 0;

    public void UpdateByAbility(Ability ability)
    {
        float cooldown01 = ability.GetCooldown01();
        Sprite icon = ability.GetIcon();
        int TotalUses = ability.TotalUses;
        ForegroundImage.fillAmount = cooldown01;
        if (cooldown01 < 1f)
        {
            ButtonBackground.color = Color.gray;

        }
        else
        {
            ButtonBackground.color = Color.white;
        }

        ForegroundImage.sprite = icon;
        BackgroundImage.sprite = icon;

        TotalUsesText.text = TotalUses.ToString();
    }
    public void SetActive()
    {

    }
}
