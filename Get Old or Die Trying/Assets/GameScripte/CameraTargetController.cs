using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

[ExecuteInEditMode]
public class CameraTargetController : MonoBehaviour {
    public GameObject player;
    public float height = 20f;
    public float centerValue = 20f;
    public Camera camera;
    public LayerMask LayerMask;
    public GameObject playerModel;


    // Update is called once per frame
    void Update () {
        Vector3 pos = player.transform.position;
        pos.x = pos.x - centerValue;
        pos.z = pos.z - centerValue;
        pos.y = height + pos.y;
        transform.position = pos;

        Vector3 screenPos = camera.WorldToScreenPoint(pos);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        Debug.Log(screenPos);
        if(Physics.Raycast(ray, out hit, 999f, LayerMask.value))
        {

            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.GetComponent<PlayerController>() == null)
            {
                playerModel.GetComponent<Outline>().enabled = true;
            } else
            {
                playerModel.GetComponent<Outline>().enabled = false;
            }
        }


    
    }
}
