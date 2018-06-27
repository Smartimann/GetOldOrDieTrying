using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteBeete : Ability {
    public RoteBeeteSettings Settings;

    public override void Execute(Character caster, RaycastHit hit) {
        if (TimeSinceLastUse < Settings.Cooldown || Settings.Count <= 0)
            return;
        
        caster.Health += Settings.Regeneration;
        Settings.Count -= 1;
    }

    protected override float GetCooldown()
    {
        return Settings.Cooldown;
    }

    public override Sprite GetIcon()
    {
        return Settings.Icon;
    }
}
