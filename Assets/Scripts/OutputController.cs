using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputController : MonoBehaviour
{

    // Output Object
    public Text outputField;
    // Caluclate maxNumberOfLines
    private float m_fontSize = 35.0f;
    private float m_maxNumberOfLines;
    private float m_numberOflines = 0;
    // Hold output
    private List<string> m_outputList = new List<string>();
    private string m_outputString;

    // Use this for initialization
    void Start () {

        // Calculate the number of lines that fit on the screen
        m_maxNumberOfLines = Mathf.Floor((Screen.height / m_fontSize) - 2);
        Debug.Log(m_maxNumberOfLines);
        outputField.supportRichText = true;
       // m_outputString = outputField.text;
        //Text textField
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FormatOutput(string _output)
    {
        m_outputString = _output;
        // Max Number of lines reached
        if(m_numberOflines >= m_maxNumberOfLines)
        {
            m_numberOflines--;
            m_outputList.RemoveAt(0);
        }
        
        if(m_numberOflines < m_maxNumberOfLines)
        {
            m_numberOflines++;
            m_outputList.Add(m_outputString);
            UpdateOutput();

        }
        
        //outputField.text = m_outputString;
    }

    private void UpdateOutput()
    {
        for(int lineIndex = 0; lineIndex < m_outputList.Count; ++lineIndex)
        {
            if(lineIndex == 0)
            {
                outputField.text = m_outputList[lineIndex];
            }
            else
            {
                outputField.text = outputField.text + "\n" + m_outputList[lineIndex];
            }
        }
    }
}
