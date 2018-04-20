using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour {
    public GameObject player;
    public float height = 20f;
    public float centerValue = 20f;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.transform.position;
        pos.x = pos.x - centerValue;
        pos.z = pos.z - centerValue;
        pos.y = height + pos.y;
        transform.position = pos;
        
	}
}
