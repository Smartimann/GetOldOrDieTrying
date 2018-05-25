using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KillSkeletons : AbstractQuest {


    public GameObject NPC;
    public string QuestName = "Kill-Skeletons";
    public string Text;
    public bool started;
    public bool finished;
    public Objective[] Objectives;


    void Start()
    {
        Objectives = GetComponentsInChildren<Objective>();
        started = false;
        finished = false;
        Text = "Hey du da. Auch wenn du ein Mensch bist. Ich bräuchte da deine Hilfe. Vielleicht hast du sie schon gesehen. Hier sind überall Skelette, kannst du die weghauen?";
        
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
        NPC.GetComponent<GoodNPCController>().AvailableQuest = false;

    }

    public override void CheckIfFullfilled()
    {
        finished = Objectives.All(x => x.ObjectiveCompleted);
    }

    public override bool GetStatus()
    {
        return finished;
    }

    public override string GetName()
    {
        return QuestName;
    }

    public override string GetText()
    {
        return Text;
    }

}
