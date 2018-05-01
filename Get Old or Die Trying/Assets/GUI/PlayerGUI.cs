using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGUI : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject AbilityBarBase;
    private Toggle[] _abilityBarToggles;
    public Image HealthBar, ManaBar, RipImage;
    public Image Ability1Image, Ability2Image;
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

    public void SetAbility1Cooldown(float cooldown01)
    {
        Ability1Image.fillAmount = cooldown01;
    }

    public void SetAbility2Cooldown(float cooldown01)
    {
        Ability2Image.fillAmount = cooldown01;
    }

    private void OnEnable()
    {
        playerController = FindObjectOfType<PlayerController>();
        _abilityBarToggles = AbilityBarBase.GetComponentsInChildren<Toggle>();
    }

    // verhindert das beim umschalten der buttons in der aktionsleiste der alte wert den neuen überschreibt
    private bool _allowActiveAbilityIndexChangeByButtons = false; 
    public void SetActiveAbility(int index)
    {
        _allowActiveAbilityIndexChangeByButtons = false;
        for (int i = 0; i < _abilityBarToggles.Length; i++)
        {
            _abilityBarToggles[i].isOn = (i + 1) == index;
        }
        _allowActiveAbilityIndexChangeByButtons = true;
    }
    public void GetButton1(bool state)
    {
        if (state && _allowActiveAbilityIndexChangeByButtons)
        {
            playerController.aBase.AbilityActiveIndex = 1;
        }
    }

    public void GetButton2(bool state)
    {
        if (state && _allowActiveAbilityIndexChangeByButtons)
        {
            playerController.aBase.AbilityActiveIndex = 2;
        }
    }

}
