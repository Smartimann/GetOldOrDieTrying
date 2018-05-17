using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "PlayerCharacterSheet", menuName = "Abilitys/Skills")]
public class AbilityBase : ScriptableObject
{

    public Ability[] ability = new Ability[9];
    //Prefabs for Skills (see Skills below)
    public GameObject fireballPrefabREMOVEMEFORGODSSAKE;

    public int Strength = 20;
    public int Dexterity = 20;
    public int Agility = 20;
    public int Intelligence = 20;
    public int AlienPower = 20;
    public int Health = 100, Mana = 100;

    //Decay attributes
    private float strengthDecay = 0;
    private float dexterityDecay = 0;
    private float agilityDecay = 0;
    private float intelligenceDecay = 0;
    private float alienPowerDecay = 0;


    private int abilityCounter = 0;
    private int strengthCounter = 0, dexterityCounter = 0, agilityCounter = 0, intelligenceCounter = 0, alienPowerCounter = 0;


    //State Skill
    public int AbilityActiveIndex = 1;

    //ClickMarker
    public GameObject ClickMarker;
    public GameObject[] clickMarkers = new GameObject[1];

    /*--------------------------------
     -------SKILLS--------------------
     --------------------------------*/
    //Wertet aus was getan wird

    public RaycastHit Hit { get; private set; }
    public void DoSomething(RaycastHit hit, Transform casterTransform, NavMeshAgent navMeshAgent, out Vector3[] outPathCorners)
    {
        //this.CasterTransform = casterTransform;

        outPathCorners = navMeshAgent.path.corners;
    }

    //Sprechen: Sprich mit NPC

    //Fireball: benutzt strength und alienPower
    [System.NonSerialized] float lastTimeFired;



    public void DecayCalculation()
    {
        strengthDecay = (float)strengthCounter / abilityCounter;
        dexterityDecay = (float)dexterityCounter / abilityCounter;
        agilityDecay = (float)agilityCounter / abilityCounter;
        intelligenceDecay = (float)intelligenceCounter / abilityCounter;
        alienPowerDecay = (float)alienPowerCounter / abilityCounter;

        Debug.Log("Decay of Values: " + "strength:" + strengthDecay + "\n" + "dexterity:" + dexterityDecay + "\n" + "agility: " + agilityDecay + "\n" + "intelligence:" + intelligenceDecay + "\n" + "alienPower: " + alienPowerDecay + "\n");
        //Debug.LogFormat("strength",strengthDecay, "dexterity", dexterityDecay, "agility", agilityDecay, "intelligence", intelligenceDecay, "alienPower", alienPowerDecay);
    }



}



