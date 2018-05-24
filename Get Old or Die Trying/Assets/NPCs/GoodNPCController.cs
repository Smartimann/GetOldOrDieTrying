using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNPCController : MonoBehaviour {
    public PlayerGUI playerGUI;
    public AbstractQuest KillSkeletons;// Use this for initialization
	void Start () {
        
        playerGUI = FindObjectOfType<PlayerGUI>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ShowDialogueText()
    {
        playerGUI.ShowDialogue();
        KillSkeletons.StartQuest();
    }

    
}
