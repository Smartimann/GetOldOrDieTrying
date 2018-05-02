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
    public GameObject EnemyHealthBarRoot;
    [SerializeField] private GameObject lastEnemyHealtBarTarget;
    public Image EnemyHealthBar;
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

    public void SetEnemyHealthBar(GameObject enemy, float health01)
    {
        lastEnemyHealtBarTarget = enemy;
        EnemyHealthBarRoot.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        EnemyHealthBar.fillAmount = health01;
    }

    public void Update()
    {
        if (lastEnemyHealtBarTarget != null)
        {
            EnemyHealthBarRoot.SetActive(true);
            EnemyHealthBarRoot.GetComponent<RectTransform>().position =
                Camera.main.WorldToScreenPoint(lastEnemyHealtBarTarget.transform.position);
        }
        else
        {
            EnemyHealthBarRoot.SetActive(false);
        }
       
    }


}
