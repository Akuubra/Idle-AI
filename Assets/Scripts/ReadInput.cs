using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour {

    public InputField inputField;
    private string m_textField;
    private string m_inputString;


    // Checks if there is anything entered into the input field.
    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
    }

    // Use this for initialization
    void Start () {

        //inputField.onEndEdit.AddListener(delegate { LockInput(inputField); });
    }
	
	// Update is called once per frame
	void Update () {
        inputField.ActivateInputField();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ReadInputField();
            inputField.text = "";
        }
    }

    public void ReadInputField()
    {
        m_textField = inputField.text;
        m_inputString = "";
        // If not null or empty
        if(!string.IsNullOrEmpty(m_textField))
        {
            // Read in value;
            m_inputString = m_textField;
            Debug.Log(m_inputString);
        }
            
    }

    public void SetInputFieldActive()
    {
        if (!inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
    }

    public string GetInputString()
    {
        return m_inputString;
    }
}
