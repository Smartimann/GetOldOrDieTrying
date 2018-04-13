using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCharacterSheet", menuName = "Abilitys/Skills")]
public class AbilityBase : ScriptableObject
{


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

    /*--------------------------------
     -------SKILLS--------------------
     --------------------------------*/

    //Fireball: benutzt strength und alienPower
    public void Fireball(Ray ray, Transform transform)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var newFireball = GameObject.Instantiate(fireballPrefabREMOVEMEFORGODSSAKE);
            Vector3 vectorToHit = hit.point - transform.position;
            Vector3 directionToHit = vectorToHit;
            directionToHit.y = 0; // dont allow projectiles to travel into the ground
            newFireball.transform.position = transform.position + directionToHit.normalized;
            newFireball.GetComponent<FireballProjectile>().Direction = directionToHit.normalized;
            newFireball.GetComponent<FireballProjectile>().Direction = directionToHit.normalized;
            Mana -= 5;

            //raising Counters
            abilityCounter += 1;
            intelligenceCounter += 1;
            alienPowerCounter += 1;

            DecayCalculation();
        }
    }

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



