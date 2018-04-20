using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GeneralSettings : MonoBehaviour {

    public Color globalShadowColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Shader.SetGlobalColor("_gShadowColor", globalShadowColor);
	}
}
