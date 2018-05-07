using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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


    //State Skill
    public int AbilityActiveIndex = 1;

    //ClickMarker
    public GameObject ClickMarker;
    public GameObject[] clickMarkers = new GameObject[1];

    /*--------------------------------
     -------SKILLS--------------------
     --------------------------------*/
    //Wertet aus was getan wird
    public void DoSomething(RaycastHit hit, Transform casterTransform, NavMeshAgent navMeshAgent)
    {

        Debug.Log("Object hit: " + hit.collider.gameObject.name);
        //Interacting with enemy
        if (hit.collider.gameObject.GetComponent<NPCController>() != null)
        {
            switch(AbilityActiveIndex)
            {
                case 1:
                    Punch(hit, casterTransform);
                    break;

                case 2:
                    Fireball(hit, casterTransform);
                    break;
            }

        }
        else if(hit.collider.gameObject.GetComponent<GoodNPCController>() != null)
        {
            Talk(hit, casterTransform);
        } else 
        {
            navMeshAgent.destination = hit.point;
            if (hit.collider.gameObject.tag == "Floor")
            {
                if (clickMarkers[0] != null)
                {
                    Destroy(clickMarkers[0]);
                }
                clickMarkers[0] = Instantiate(ClickMarker, hit.point, ClickMarker.transform.rotation);
                Debug.Log("Marker");

            }

        }

    }

    //Sprechen: Sprich mit NPC
    public void Talk(RaycastHit hit, Transform casterTransform)
    {
        hit.collider.GetComponent<GoodNPCController>().ShowDialogueText();

    }

    //Fireball: benutzt strength und alienPower
    [System.NonSerialized] float lastTimeFired;

    public float FireballCooldown = 1f;
    public void Fireball(RaycastHit hit, Transform casterTransform)
    {
        if (Time.time - lastTimeFired >= FireballCooldown)
        {
            var newFireball = GameObject.Instantiate(fireballPrefabREMOVEMEFORGODSSAKE);
            Vector3 vectorToHit = hit.point - casterTransform.position;
            Vector3 directionToHit = vectorToHit;
            directionToHit.y = 0; // dont allow projectiles to travel into the ground
            newFireball.transform.position = casterTransform.position + directionToHit.normalized;
            newFireball.GetComponent<FireballProjectile>().Direction = directionToHit.normalized;
            newFireball.GetComponent<FireballProjectile>().Direction = directionToHit.normalized;
            Mana -= 5;
         
            //raising Counters
            abilityCounter += 1;
            intelligenceCounter += 1;
            alienPowerCounter += 1;

            DecayCalculation();
            lastTimeFired = Time.time;    
        }
    }

    [System.NonSerialized] float lastTimePunch;

    public float PunchCooldown = 1f;
    public void Punch(RaycastHit hit, Transform casterTransform)
    {   
        GameObject enemy = hit.collider.gameObject;
        float distance = Vector3.Distance(casterTransform.position, enemy.transform.position);
        Debug.Log(distance);
        if (enemy.GetComponent<NPCController>() != null)
        {
            if (distance <= 2f)
            {
                if (Time.time - lastTimePunch >= PunchCooldown)
                {
                    enemy.GetComponent<NPCController>().Damage(10);

                    //raising Counters
                    abilityCounter += 1;
                    strengthCounter += 1;
                    agilityCounter += 1;

                    DecayCalculation();

                    lastTimePunch = Time.time;

                }
            }                 
        }           
    }


    public void UpdateCooldownsGUI(PlayerGUI playerGui)
    {
        playerGui.SetAbility1Cooldown(Mathf.Clamp01((Time.time - lastTimePunch) / PunchCooldown));
        playerGui.SetAbility2Cooldown(Mathf.Clamp01((Time.time - lastTimeFired) / FireballCooldown));
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



