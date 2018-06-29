using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerBank : Ability {

	public Text Count;
	public PowerBankSettings Settings;

    public void Start() {
        Count.text = Settings.Count.ToString();

    }
	 public override void Execute(Character caster, RaycastHit hit) {
        if (TimeSinceLastUse < Settings.Cooldown || Settings.Count <= 0)
            return;
        caster.Mana += Settings.Regeneration;
        Settings.Count -= 1;
		Count.text = Settings.Count.ToString();
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
