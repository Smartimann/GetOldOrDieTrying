using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamageTrigger : MonoBehaviour
{

    public float lastHit = 0f;
    public float hitSpeed = 1f;
    private void OnTriggerStay(Collider other)
    {
        if (Time.time - lastHit > hitSpeed)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Damage(5);
                lastHit = Time.time;
            }

          
        }

    }
}
