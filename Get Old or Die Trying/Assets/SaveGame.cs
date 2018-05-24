using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveGame")]
public class SaveGame : MonoBehaviour {
    public List<string> quests = new List<string>();


    public void SaveQuest(string name)
    {

        quests.Add(name);
    }
    



}
