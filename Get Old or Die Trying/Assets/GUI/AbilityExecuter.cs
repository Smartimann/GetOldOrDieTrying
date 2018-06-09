using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Versucht Fähigkeit auszuführen. Für Inventarplätze
/// </summary>
public class AbilityExecuter : MonoBehaviour, IPointerClickHandler
{
    public KeyCode KeyCode;

    public static Ability SelectedAbility ;

    Ability GetAbilityInSlot()
    {
        return GetComponentInChildren<Ability>();
    }
	// Update is called once per frame
	void Update ()
	{
	    var abilityInSlot = GetAbilityInSlot();
	    bool shouldTintBackground = SelectedAbility != null && SelectedAbility == abilityInSlot;
        // change color of slot background based where this slot is selected
        GetComponent<Image>().color = shouldTintBackground ? Color.white : Color.clear;

        if (Input.GetKeyDown(KeyCode))
        {
            SetAbilityInSlotAsActive();
        }

       

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetAbilityInSlotAsActive();
    }

    void SetAbilityInSlotAsActive()
    {
        var abiltiyInChildren = GetAbilityInSlot();
        if (abiltiyInChildren != null)
        {
            SelectedAbility = abiltiyInChildren;
        }
    }
}
