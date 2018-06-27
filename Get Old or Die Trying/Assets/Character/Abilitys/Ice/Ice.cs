using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Ability
{
	
	public IceSettings Settings;

    
	public override void Execute(Character caster, RaycastHit hit)
    {

	if (TimeSinceLastUse < Settings.Cooldown)
				return;

			Transform casterTransform = caster.transform;

			var newSnowman = Instantiate(Settings.SnowManPrefab);
			Vector3 vectorToHit = caster.casterTarget - casterTransform.position;
			Vector3 directionToHit = vectorToHit;
			directionToHit.y = 0; // dont allow projectiles to travel into the ground
			newSnowman.transform.position = caster.transform.position + directionToHit.normalized;
			var projectile = newSnowman.GetComponent<FireballProjectile>();
			projectile.Direction = directionToHit.normalized;
			projectile.damage = Settings.Damage;

			bool isCasterPlayer = caster.GetType() == typeof(PlayerController);
			if (isCasterPlayer)
			{
				projectile.Velocity = Settings.Speed / Mathf.Max(TotalUses, 1);
				Debug.Log("Ice-Attacke");
			}

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
}
