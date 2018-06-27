using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    public FireballSettings Settings;
    public override void Execute(Character caster, RaycastHit hit)
    {
        if (TimeSinceLastUse < Settings.Cooldown || caster.Mana == 0) 
            return;

        Transform casterTransform = caster.transform;

        var newFireball = Instantiate(Settings.FireballPrefab);
        Vector3 vectorToHit = caster.casterTarget - casterTransform.position;
        Vector3 directionToHit = vectorToHit;
        directionToHit.y = 0; // dont allow projectiles to travel into the ground
        newFireball.transform.position = caster.transform.position + directionToHit.normalized;
        var projectile = newFireball.GetComponent<FireballProjectile>();
        projectile.Direction = directionToHit.normalized;
        projectile.damage = Settings.Damage;


        bool isCasterPlayer = caster.GetType() == typeof(PlayerController);
        if (isCasterPlayer)
        {
            projectile.Velocity = Settings.Speed / Mathf.Max(TotalUses, 1);

        }
        UseMana(caster);
        TotalUses++;
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

    private void UseMana(Character caster) {
        caster.UseMana(Settings.ManaCost);
    }
}

