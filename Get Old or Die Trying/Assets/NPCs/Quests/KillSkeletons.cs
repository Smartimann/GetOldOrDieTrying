using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KillSkeletons : AbstractQuest {


    public GameObject NPC;
    public string QuestName = "Kill-Skeletons";
    public string[] Text;
    public bool started;
    public bool finished;
    public Objective[] Objectives;


    void Start()
    {
        Objectives = GetComponentsInChildren<Objective>();
        started = false;
        finished = false;
        Text[0] = "Hey du da. Auch wenn du ein Mensch bist. Ich bräuchte da deine Hilfe. Vielleicht hast du sie schon gesehen. Hier sind überall Skelette, kannst du die weghauen?";
        
    }

    private void Update()
    {
        if (started)
        {
            CheckIfFullfilled();
        }
    }

    public override void StartQuest()
    {
        started = true;
    }

    public override void CheckIfFullfilled()
    {


        finished = Objectives.All(x => x.ObjectiveCompleted);
       
    }

 
}
