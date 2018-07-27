using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvalutor : MonoBehaviour
{
    public FunctionList functionList;
    private string m_inputString;
    private List<string> commandList = new List<string>() { "teach", "help", "bits" };


    void Start()
    {
        
    }
    void Update()
    {
        
    }
     

    public void EvaluateInput(string _inputString)
    {
        _inputString = _inputString.ToLower();
        if(!string.IsNullOrEmpty(_inputString))
        {
            // Check if it is a command
            if (commandList.Contains(_inputString))
            {
                switch (_inputString)
                {
                    case "teach":
                        functionList.Teach();
                        break;
                    case "bits":
                        functionList.ShowBits();
                        break;
                    default:
                        break;
                }
            }
            
           
        }
    }

}
