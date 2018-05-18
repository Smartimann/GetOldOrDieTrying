using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    public int TotalUses = 0;
    public abstract Sprite GetIcon();

    public abstract void Execute(Character caster);

    // shared cooldown code
    protected abstract float GetCooldown();

    protected float LastTimeUsed;

    protected float TimeSinceLastUse
    {
        get { return Time.time - LastTimeUsed; }
    }

    public virtual float GetCooldown01()
    {
        return TimeSinceLastUse / GetCooldown();
    }

    protected bool RaycastByMouse(out RaycastHit hit, int layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit, 999f, layerMask);
    }
}

public abstract class AbilitySettings : ScriptableObject
{
    public Sprite Icon;
    public float Cooldown;
}