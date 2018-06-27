using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAbility : Ability
{
    public SwordAbilitySettings Settings;

    public override void Execute(Character caster, RaycastHit hit)
    {
        if (TimeSinceLastUse < Settings.Cooldown)
            return;

        Matrix4x4 localToWorldMatrix = Matrix4x4.identity;

        Vector3 boundsMin = Settings.SwordRangeBounds.min;
        Vector3 boundsMax = Settings.SwordRangeBounds.max;
        Bounds worldSpaceBounds = new Bounds();
        worldSpaceBounds.SetMinMax(boundsMin, boundsMax);
        var colliders = Physics.OverlapBox(
            worldSpaceBounds.center + caster.transform.position,
            worldSpaceBounds.extents,
            caster.transform.rotation);

        foreach (var collider in colliders)
        {
            GameObject enemy = collider.gameObject;
            if (enemy.GetComponent<NPCController>() != null)
            {
               
                float distance = Vector3.Distance(caster.transform.position, enemy.transform.position);
                Debug.Log(distance);
                enemy.GetComponent<NPCController>().Damage(Settings.Damage);
                LastTimeUsed = Time.time;
            }
        }
    }

    public override Sprite GetIcon()
    {
        return Settings.Icon;
    }

    protected override float GetCooldown()
    {
        return Settings.Cooldown;
    }

    private void OnDrawGizmos()
    {
        Matrix4x4 oldGizmoMatrix4X4 = Gizmos.matrix;
        Gizmos.matrix *= transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(Settings.SwordRangeBounds.center, Settings.SwordRangeBounds.size);
        Gizmos.matrix = oldGizmoMatrix4X4;
    }
}


