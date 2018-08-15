using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvalutor : MonoBehaviour
{
    public FunctionList functionList;
    public OutputController outputController;
    private string m_inputString;
    private List<string> commandList = new List<string>() { "teach", "help", "bits", "upgrade" };
    private List<string> upgradeList = new List<string>() { };


    void Start()
    {
        
    }
    void Update()
    {
        
    }
     

    public void EvaluateInput(string _inputString)
    {
        if(!string.IsNullOrEmpty(_inputString))
        {
            // Check if it is a command
            if (commandList.Contains(_inputString.ToLower()))
            {
                m_inputString = _inputString.ToLower();
                outputController.FormatOutput(">" + m_inputString);
                switch (m_inputString)
                {
                    case "teach":
                        functionList.Teach();
                        break;
                    case "bits":
                        functionList.ShowBits();
                        break;
                    case "help":
                        functionList.Help();
                        break;
                    case "upgrade":
                        functionList.ShowUpgrades();
                        break;
                    default:
                        break;
                }
            }
            else if (upgradeList.Contains(_inputString.ToLower()))
            {
                m_inputString = _inputString.ToLower();
                outputController.FormatOutput(">" + m_inputString);
                switch (m_inputString)
                {
                    default:
                        break;
                }
            }
            else
            {
                // Unknown Input 
                
                functionList.UnknownInput(_inputString);
            }
            
           
        }
    }

}
