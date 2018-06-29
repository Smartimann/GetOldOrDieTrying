using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Highlighting : MonoBehaviour {
    public Outline line;

    private void Start()
    {
        line = GetComponent<Outline>();
        line.enabled = false;
    }
    // Use this for initialization
    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        line.enabled = true;
    }


    private void OnMouseExit()
    {
        Debug.Log("MouseExit");
        line.enabled = false;

    }
}
