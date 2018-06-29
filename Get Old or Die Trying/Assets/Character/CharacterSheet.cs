using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSheet", menuName = "Character Sheet")]
public class CharacterSheet : ScriptableObject
{
    [Header(("Initial Stats"))]
    public int Health = 100;
    public int Mana = 100;
    public int Money = 100;
    public int Age = 30;

    public float ManaRefillRate = 0.1f;


    //Generelle Attribute

    public int Attack = 100;
    public int Defense = 100;

    public int MaxHealth = 200;
    public int MaxMana = 200;

    public int Speed = 20;

    //



}
