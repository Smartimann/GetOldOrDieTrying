using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireballSettings", menuName = "Abilitys/Fireball")]
public class FireballSettings : AbilitySettings
{
    public GameObject FireballPrefab;
    public int Damage;
    public float Speed;
}
