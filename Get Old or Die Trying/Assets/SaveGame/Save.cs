using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    public SaveGame SaveGame;
    public GameObject QuestContainer;
    public GameObject[] Quests;
    
    // Update is called once per frame
    private void Update()
    {
        foreach (var quest in Quests)
        {
            bool finished = quest.GetComponent<AbstractQuest>().GetStatus();
            string name = quest.GetComponent<AbstractQuest>().GetName();
            if ( finished && !(SaveGame.FinishedQuests.Contains(name)))
            {
                SaveGame.SaveQuest(quest.GetComponent<AbstractQuest>().GetName());
                Debug.Log("Quest Saved");        
            }
        }
    }
}
