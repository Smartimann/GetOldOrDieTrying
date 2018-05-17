using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSheet", menuName = "Character Sheet")]
public class CharacterSheet : ScriptableObject
{
    public int Health = 100, Mana = 100;
    public float ManaRefillRate = 0.1f;
}
