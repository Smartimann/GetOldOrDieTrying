using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityBar : MonoBehaviour
{
    private PlayerController playerController;
    private Toggle[] toggles;
    private void OnEnable()
    {
        playerController = FindObjectOfType<PlayerController>();
        toggles = GetComponentsInChildren<Toggle>();
    }



}
