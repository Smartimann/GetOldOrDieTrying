using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public PlayerGUI playerGUI;
    void Start()
    {
        playerGUI = FindObjectOfType<PlayerGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowDialogueText()
    {
        playerGUI.ShowStore();
       
       
    }


}
