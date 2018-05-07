using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMarkerController : MonoBehaviour {
    private float range;
    private float count;
    private float rate;
    private bool up;
    private bool down;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        range = 0.3f;
        count = 0;
        rate = 0.02f;
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //Das FUnktioniert noch nicht
        if(Player.transform.position.x == transform.position.x && Player.transform.position.z == transform.position.z)
        {
            Destroy(this);
            Debug.Log("Selbe Position");
        }

        if (count <= 0)
        {
            up = true;
            down = false;
        } else if (count >= range)
        {
            up = false;
            down = true;
        }


        if (up)
        {
            transform.position = transform.position  + new Vector3(0, rate);
            count += rate;

        }
        else if (down)
        {
            transform.position = transform.position - new Vector3(0, rate);
            count -= rate;


        }
    }
}
