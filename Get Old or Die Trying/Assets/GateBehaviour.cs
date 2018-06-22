using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour {
    public GameObject Player;
    bool inXRange;
    bool inYRange;
    // Use this for initialization
    float width = 5f;
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        inXRange = Player.transform.position.x > this.transform.position.x - width && Player.transform.position.x < this.transform.position.x + width;
        inYRange = Player.transform.position.y > this.transform.position.y - width && Player.transform.position.y < this.transform.position.y + width;
        if (inXRange && inYRange)
        {
            Player.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(new Vector3(-475.0595f, -165.8549f, 260.9867f));
            //Player.transform.position = new Vector3(-500f, -168.5f, 263f);
            Debug.Log("Entered");
        }
    }
}
