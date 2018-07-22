using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectInputField : MonoBehaviour {

    public int MAX_LINES = 24;

    public string InputText = "";
    public int lines = 0;
    public static bool autoFill = false;

    public List<string> OutputList = new List<string>();

    public InputField mainInputField;
    public InputField outputField;
    public Text OutputText;
    public GameObject InputReader;

	// Use this for initialization
	void Start () {

        mainInputField.GetComponent<InputField>().Select();

        ///OnClickListener to take input from the input text field check if it is not null
        ///then add it to a list
        ///the list is then used to populate the output box
        ///

        AddTextReformat("Enter 'Help' to get started", false);

        mainInputField.onEndEdit.AddListener(delegate
        {

            // Read Input
            ReadText();
            AddTextReformat(InputText, true);


        });

	}

    //void 

    public void AddTextReformat(string Input, bool command)
    {
        // If lines are at maximum
        if (!Input.Equals("") && lines >= 24)
        {
            // Remove top line so that more can be added
            lines--;
            OutputList.RemoveAt(0);
        }

        // If text is not empty and the total number of lines is less than the maxium
        if (!Input.Equals("") && lines < 24)
        {
            lines++;
            
            if (command)
            {
                //Add command format
                Input = ">" + Input;

                //Change color of the Input
                //OutputText.GetComponent<Text>().color = Color.green;

                // Add input to output list
                OutputList.Add(Input);

                //OutputText.GetComponent<Text>().color = Color.white;

                // Send Input to Reader
                InputReader.GetComponent<TextInput>().ReadInput(Input);
            }
            else
            {
                // Add input to output list
                OutputList.Add(Input);
            }
           
            // Iterate List and add items to output
            for (int i = 0; i < OutputList.Count; i++)
            {
                if (i == 0)
                {
                    
                    //
                    outputField.GetComponent<InputField>().text = OutputList[i];
                    //outputField.GetComponent<InputField>()
                    //outputField.GetComponent<Text>().color = Color.green;
                }
                else
                {
                    outputField.GetComponent<InputField>().text = outputField.GetComponent<InputField>().text + "\n" + OutputList[i];
                }

            }

            ///
            if(autoFill && (TextInput.upgrades == false)) //checks whether or not the auto teach upgrade has been bought
            {
                mainInputField.GetComponent<InputField>().text = "Teach";
            }
            else
            {
                mainInputField.GetComponent<InputField>().text = "";
            }
            ///
        }

        mainInputField.GetComponent<InputField>().ActivateInputField();
    }
	
	// Update is called once per frame
	void Update () {

        // If the InputText box is not selected select it
        if(mainInputField.GetComponent<InputField>().isFocused == false)
        {
            mainInputField.GetComponent<InputField>().ActivateInputField();
        }
		
	}
    void ReadText()
    {
        // Read the contents of the InputText box into a string
        InputText = mainInputField.GetComponent<InputField>().text.ToString();
    }

}
