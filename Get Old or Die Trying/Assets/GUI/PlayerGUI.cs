using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGUI : MonoBehaviour
{
    public static PlayerGUI Instance;

    private PlayerController playerController;

    public GameObject AbilityBarBase;
    private Toggle[] _abilityBarToggles;
    public Image HealthBar, ManaBar, RipImage;
    public Image Ability0Image, Ability1Image;
    public GameObject EnemyHealthBarRoot;
    [SerializeField] private GameObject lastEnemyHealtBarTarget;
    public Image EnemyHealthBar;

    public GameObject PlayerUI;
    public GameObject Dialogue;
    public Button quitButton;

    public GameObject InventoryRoot;

    public Text AgeText;
    public AbilityButton[] AbilityButtons;
    private void Awake()
    {
        Instance = this;
        AbilityButtons = GetComponentsInChildren<AbilityButton>();
        // setup index for abilitybuttons. the index follows the order they appear in the gui
        for (int i = 0; i < AbilityButtons.Length; i++)
        {
            AbilityButtons[i].index = i;
        }
    }

    private void Start()
    {

        quitButton.onClick.AddListener(HideDialogue);
        PlayerUI.SetActive(true);
        Dialogue.SetActive(false);

    }

    //In dieses System könnte auch die Pausierung eingebaut werden
    public void ShowDialogue()
    {
        
        PlayerUI.SetActive(false);
        Dialogue.SetActive(true);
        GameController.PauseGame();

    }

    public void HideDialogue()
    {
        PlayerUI.SetActive(true);
        Dialogue.SetActive(false);
        GameController.ResumeGame();
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
            _abilityBarToggles[i].isOn = i == index;
        }
        _allowActiveAbilityIndexChangeByButtons = true;
    }

    public void GetButton1(bool state)
    {
        if (state && _allowActiveAbilityIndexChangeByButtons)
        {
            playerController.AbilityActiveIndex = 1;
        }
    }

    public void GetButton2(bool state)
    {
        if (state && _allowActiveAbilityIndexChangeByButtons)
        {
            playerController.AbilityActiveIndex = 2;
        }
    }

    public void SetEnemyHealthBar(GameObject enemy, float health01)
    {
        lastEnemyHealtBarTarget = enemy;
        EnemyHealthBarRoot.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        EnemyHealthBar.fillAmount = health01;
    }

    public void SetInventory(bool isActive)
    {
       InventoryRoot.SetActive(isActive);

        Camera main = Camera.main;

        Rect cameraRect = main.rect;
        cameraRect.x = isActive ? 0.5f : 0f;
        main.rect = cameraRect;
        
    }

    public void Update()
    {
        UpdateEnemyHealthBar();
        UpdateAbilityGUI();
        UpdatePlayerStats();
    }

    void UpdateEnemyHealthBar()
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

    void UpdateAbilityGUI()
    {
        var abilities = playerController.Abilities;
        for (int i = 0; i < playerController.Abilities.Length; i++)
        {
            if (abilities[i] != null)
            {
                AbilityButtons[i].UpdateByAbility(abilities[i]);
            }
     
        }
    }

    void UpdatePlayerStats()
    {
        HealthBar.fillAmount = (float)playerController.Health / 100f;
        if (playerController.Health <= 0)
        {
            RipImage.enabled = true;
        }

        ManaBar.fillAmount = (float)playerController.Mana / 100f;

        AgeText.text = "Age: " + playerController.Age;
    }
}
