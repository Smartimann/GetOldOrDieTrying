using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    public FireballSettings Settings;
    public override void Execute(Character caster)
    {
        if (TimeSinceLastUse < Settings.Cooldown)
            return;

        Transform casterTransform = caster.transform;

        var newFireball = Instantiate(Settings.FireballPrefab);
        Vector3 vectorToHit = caster.casterTarget - casterTransform.position;
        Vector3 directionToHit = vectorToHit;
        directionToHit.y = 0; // dont allow projectiles to travel into the ground
        newFireball.transform.position = caster.transform.position + directionToHit.normalized;
        newFireball.GetComponent<FireballProjectile>().Direction = directionToHit.normalized;
        newFireball.GetComponent<FireballProjectile>().damage = Settings.Damage;
        //Mana -= 5;

        //raising Counters
        //abilityCounter += 1;
        //intelligenceCounter += 1;
        //alienPowerCounter += 1;

        //DecayCalculation();
        LastTimeUsed = Time.time;

    }

    public override Sprite GetIcon()
    {
        return Settings.Icon;
    }

    protected override float GetCooldown()
    {
        return Settings.Cooldown;
    }
}

