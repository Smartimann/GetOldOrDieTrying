using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : Objective {
    public GameObject[] enemys;
    private void Update()
    {
        ObjectiveCompleted = true;
        foreach (var enemy in enemys)
        {
            if (enemy != null || enemy.GetComponent<Character>().Health > 0)
            {
                ObjectiveCompleted = false;
            } 
        }

        
    }

}
