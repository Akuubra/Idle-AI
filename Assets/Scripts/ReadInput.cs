using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour {

    public InputField inputField;
    public InputEvalutor inputEvalutor;
    private string m_textField;
   // private string m_inputString;

    // Use this for initialization
    void Start ()
    {
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Keeps the InputField Selected at all times
        SetInputFieldActive();
        // Reads the input if the enter key is pressed
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ReadInputField();
            inputField.text = "";
        }
    }
    
    //Takes the text of the input field and checks whether its null or empty, if not send it to the evaluator
    public void ReadInputField()
    {
        m_textField = inputField.text;
        // If not null or empty
        if(!string.IsNullOrEmpty(m_textField))
        {
            // Read in value;
            inputEvalutor.EvaluateInput(m_textField);
            Debug.Log(m_textField);
        }
            
    }

    // Keeps the inputfield active
    public void SetInputFieldActive()
    {
        if (!inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
    }
}
