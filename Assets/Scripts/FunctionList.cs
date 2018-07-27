using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionList : MonoBehaviour {

    public OutputController outputController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Teaches the AI a bit based on the bit multiplier
    public void Teach()
    {
        ResourceController.IncrementBits();
        Debug.Log("Teach()");
    }
    public void ShowBits()
    {
        outputController.FormatOutput(ResourceController.GetBits().ToString());
        Debug.Log("ShowBits()");
    }
}
