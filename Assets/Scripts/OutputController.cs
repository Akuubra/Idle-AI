using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputController : MonoBehaviour {

    public InputField outputField;
    private string m_outputString;

	// Use this for initialization
	void Start () {
        m_outputString = outputField.GetComponent<Text>().text;
        //Text textField
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OutputString(string _output)
    {
       m_outputString = _output;
    }
}
