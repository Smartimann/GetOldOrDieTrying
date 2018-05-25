using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNPCController : MonoBehaviour {
    public PlayerGUI playerGUI;
    public AbstractQuest KillSkeletons;// Use this for initialization
    public GameObject QuestMarker;
    public bool AvailableQuest;
	void Start () {
        AvailableQuest = true;
        playerGUI = FindObjectOfType<PlayerGUI>();
    }

    // Update is called once per frame
    void Update () {
		QuestMarker.SetActive(AvailableQuest);        
	}

    public void ShowDialogueText()
    {

        playerGUI.ShowDialogue(KillSkeletons.GetText());
        KillSkeletons.StartQuest();

    }

    
}
