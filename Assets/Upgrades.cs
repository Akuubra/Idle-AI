using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour {

    public Dictionary<int, string> upgradeDict = new Dictionary<int, string>()
    {
        {10, "Autofill teach"},
        {20, "Auto teach 1"},
        {50, "Auto teach 2"},
        {100, "Auto teach 3"},
        {200, "Auto teach 4"},
        {1000, "Manual Teaching"}
    };

    public Dictionary<string, string> upgradeDescriptionDict = new Dictionary<string, string>()
    {
        {"autofill teach", "This upgrade automatically fills the Input Text bar with the command 'Teach'."},
        {"auto teach 1", "This upgrade will passively teach the Singularity." }
        
    };

    public Dictionary<int, string> availableUpgradesDict = new Dictionary<int, string>();
    private bool autoTeach = false;
    private float autoTeachTimer = 1.0f;
    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if((timer > (1.0f/autoTeachTimer)) && autoTeach)
        {
            GetComponent<FunctionList>().reduceBits(-1);
            timer = 0;
        }
		
	}

    public void switchInput(string Input)
    {
        Input = Input.ToLower();
        //Input = Input.Substring(1);   
        //print(Input);
        switch(Input)
        {
            case "autofill teach":
                if (this.GetComponent<FunctionList>().getBits() >= 10)
                {
                    string value;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("autofill teach", out value))
                    {
                        GetComponent<FunctionList>().showDescription(value);
                    }
                    SelectInputField.autoFill = true;
                    cleanupUpgrade(10);
                }
                else
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }
                break;
            case "auto teach 1":
                if (this.GetComponent<FunctionList>().getBits() >= 20)
                {
                    //Add Functionality
                    string value;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("auto teach 1", out value))
                    {
                        GetComponent<FunctionList>().showDescription(value);
                    }
                    autoTeach = true;
                    cleanupUpgrade(20);
                }
                else
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }
                break;
            case "auto teach 2":
                if(this.GetComponent<FunctionList>().getBits() >= 50)
                {
                    string value;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("auto teach 2", out value))
                    {
                        GetComponent<FunctionList>().showDescription(value);
                    }
                    //Input Functionality
                    autoTeachTimer++;
                    cleanupUpgrade(50);
                }
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }

                break;
            case "auto teach 3":
                if(this.GetComponent<FunctionList>().getBits() >= 100)
                {
                    string value;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("auto teach 3", out value))
                    {
                        GetComponent<FunctionList>().showDescription(value);
                    }
                    //Input Functionality
                    autoTeachTimer++;
                    cleanupUpgrade(100);
                }
                else
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }

                break;
            case "auto teach 4":
                if (this.GetComponent<FunctionList>().getBits() >= 200)
                {
                    string value;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("auto teach 4", out value))
                    {
                        GetComponent<FunctionList>().showDescription(value);
                    }
                    //Input Functionality
                    autoTeachTimer++;
                    cleanupUpgrade(200);
                }
                else
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }

                break;
            case "level 1 manual teaching":
                if (this.GetComponent<FunctionList>().getBits() >= 1000)
                {
                    string value4;
                    if (GetComponent<Upgrades>().upgradeDescriptionDict.TryGetValue("level 1 manual teaching", out value4))
                    {
                        GetComponent<FunctionList>().showDescription(value4);
                    }
                    //Input functionality
                    cleanupUpgrade(1000);
                }
                else
                {
                    this.GetComponent<FunctionList>().confirmUpgrade(false);
                }

                break;
            default:
                break;
        }
    }

    public void cleanupUpgrade(int bits)
    {
        this.GetComponent<FunctionList>().reduceBits(bits);
        this.GetComponent<FunctionList>().confirmUpgrade(true);
        availableUpgradesDict.Remove(bits);
        upgradeDict.Remove(bits);
    }


}
