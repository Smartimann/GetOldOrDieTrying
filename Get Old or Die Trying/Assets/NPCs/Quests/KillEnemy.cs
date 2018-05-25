using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class KillEnemy : Objective {
    public GameObject[] enemys;
    public bool[] isDead = { false, false, false };


    private void Update()
    {
         for (int i = 0; i < enemys.Length; i++)
         {
             if (enemys[i].GetComponent<NPCController>().Health <= 0)
             {
                 isDead[i] = true;
             }
         }

        ObjectiveCompleted = isDead.All(x => x);




        
    }

}
