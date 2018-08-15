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
        //outputController.FormatOutput(">Teach");
        Debug.Log("Teach()");
    }
    public void ShowBits()
    {
        //outputController.()
        outputController.FormatOutput("Current bits: " + ResourceController.GetBits().ToString());
        Debug.Log("ShowBits()");
    }

    public void Help()
    {
        Debug.Log("Help()");
    }

    public void UnknownInput(string _output)
    {
        outputController.FormatOutput(_output);
        outputController.FormatOutput("<color=red>Error!</color> Unknown Command: " + _output);
    }

    public void ShowUpgrades()
    {

    }
}
