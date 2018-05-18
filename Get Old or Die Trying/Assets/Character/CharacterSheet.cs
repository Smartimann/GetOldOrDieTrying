using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSheet", menuName = "Character Sheet")]
public class CharacterSheet : ScriptableObject
{
    [Header(("Initial Stats"))]
    public int Health = 100;
    public int Mana = 100;

    public float ManaRefillRate = 0.1f;
}
