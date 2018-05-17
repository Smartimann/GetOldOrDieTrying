using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordAbilitySettings", menuName = "Abilitys/SwordAbilitySettings")]
public class SwordAbilitySettings : AbilitySettings
{
    public Bounds SwordRangeBounds;
    public int Damage;
}
