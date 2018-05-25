using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveGame", menuName = "System/SaveGame")]
public class SaveGame : ScriptableObject {
    public List<string> FinishedQuests = new List<string>();
    public GameObject QuestContainer;
    
    
    public void SaveQuest(string name)
    {
        FinishedQuests.Add(name);
    }
    



}
