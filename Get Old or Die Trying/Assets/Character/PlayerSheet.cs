using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSheet", menuName = "Abilitys/PlayerSheet")]
public class PlayerSheet : ScriptableObject
{
    public int Age = 30;
    [Header("Other Stats")]
    public int Strength = 20;
    public int Dexterity = 20;
    public int Agility = 20;
    public int Intelligence = 20;
    public int AlienPower = 20;
}
