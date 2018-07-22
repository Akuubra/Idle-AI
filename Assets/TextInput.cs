using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {

    public InputField mainInputField;

    public static bool upgrades = false;
    public List<string> commands = new List<string>() { "teach", "help", "upgrade", "bits", "back" };
    public List<string> upgradeList = new List<string>() { "autofill teach", "auto teach 1", "auto teach 2", "auto teach 3", "level 1 manual teaching" };

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


		
	}

    public void ReadInput(string Input)
    {
        Input = Input.ToLower();
        Input = Input.Substring(1);

        if (upgrades == false)
        {
            if (commands.Contains(Input))
            {
                switch (Input)
                {
                    case "teach":
                        this.GetComponent<FunctionList>().Teach();
                        break;
                    case "help":
                        this.GetComponent<FunctionList>().Help();
                        break;
                    case "bits":
                        this.GetComponent<FunctionList>().Bits();
                        break;
                    case "upgrade":
                        this.GetComponent<FunctionList>().showHideUpgrades(upgrades);
                        upgrades = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.GetComponent<FunctionList>().unknownCommand();
            }
        }
        else if (upgrades == true)
        {
            print(Input);
            if (commands.Contains(Input))
            {
                if (Input == "back")
                {
                    this.GetComponent<FunctionList>().showHideUpgrades(upgrades);
                    upgrades = false;
                }
                else
                {
                    this.GetComponent<FunctionList>().exitShop();
                }
                
            }
            else if(upgradeList.Contains(Input))
            {
                    this.GetComponent<Upgrades>().switchInput(Input);
            }
            else
            {
                this.GetComponent<FunctionList>().unknownCommand();

            }

            
            //this.GetComponent<FunctionList>().confirmUpgrade(Upgrades.switchInput(Input));            
        }
     }
        
        
           


        
       /* if(Input == "teach")
        {
            this.GetComponent<FunctionList>().Teach();
        }

        if(Input == "help")
        {
            this.GetComponent<FunctionList>().Help();
        }

        if(Input == "bits")
        {
            this.GetComponent<FunctionList>().Bits();
        }

        if(Input == "upgrade")
        {
            this.GetComponent<FunctionList>().Upgrades();
        }*/





    
}
