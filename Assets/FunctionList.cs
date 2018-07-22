using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionList : MonoBehaviour {

    private int bit = 0;
    public InputField InputField;
    private bool event1; //Triggers when the player learns their first bit

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getBits()
    {
        return bit;
    }

    public void reduceBits(int amount)
    {
        bit = bit - amount;
    }

    public void Teach()
    {
        bit++;

        // If the player has enough bits for an upgrade they are notified and the upgrade is added to the Available Upgrade Dictionary
        if(this.GetComponent<Upgrades>().upgradeDict.ContainsKey(bit))
        {
            InputField.GetComponent<SelectInputField>().AddTextReformat("New Upgrades Available", false);
            string value;
            // Check is redundant but it outputs the corresponding value to the bit
            if (!GetComponent<Upgrades>().upgradeDict.TryGetValue(bit, out value)) // Returns true if there exists an upgrade for the given bit value
            {
                // Will now exit the method and skip the adding of the value to available upgrade dict since there exists none
                return; // or whatever you want to do
            }
            
            GetComponent<Upgrades>().availableUpgradesDict.Add(bit, value);
        }
        // Event1: Feedback to player for using the command teach
        else if(bit == 1 && !event1)
        {
            InputField.GetComponent<SelectInputField>().AddTextReformat("Congratulations, you have taught the Singularity its first bit of information. Keep teaching!", false);
            event1 = true;
        }
    }

    public void Bits()
    {
        InputField.GetComponent<SelectInputField>().AddTextReformat("The Singularity has learned " + bit.ToString() + " bits", false);
        //InputField.GetComponent<SelectInputField>().OutputList.Add("The Singularity has learned " + bit.ToString() + " bits");

    }

    public void Help()
    {
        InputField.GetComponent<SelectInputField>().AddTextReformat("To show the Singularity's progress, type 'bits'", false);
        InputField.GetComponent<SelectInputField>().AddTextReformat("To teach the Singularity a new bit, type 'teach'", false);
        InputField.GetComponent<SelectInputField>().AddTextReformat("To view possible upgrades for your Singularity, type 'upgrade'", false);
        InputField.GetComponent<SelectInputField>().AddTextReformat("To show these options again, type 'help'", false);
        InputField.GetComponent<SelectInputField>().AddTextReformat("More commands will become available as you progress...", false);
    }

    public void showHideUpgrades(bool show)
    {
        if(!show)
        {
            if(this.GetComponent<Upgrades>().availableUpgradesDict.Count == 0)
            {
                InputField.GetComponent<SelectInputField>().AddTextReformat("There does not seem to be any available upgrades, please come back later", false);
            }
            foreach (KeyValuePair<int, string> entry in this.GetComponent<Upgrades>().availableUpgradesDict)
            {
                InputField.GetComponent<SelectInputField>().AddTextReformat(entry.Value + "...." + entry.Key.ToString() + " bits", false);
            }
            InputField.GetComponent<SelectInputField>().AddTextReformat("To buy an upgrade please type its name", false);
            InputField.GetComponent<SelectInputField>().AddTextReformat("To exit the upgrade menu, type 'back'", false);
        }
        else
        {
            InputField.GetComponent<SelectInputField>().AddTextReformat("", false);
        }
        
        //this.GetComponent<Upgrades>();
    }

    public void confirmUpgrade(bool canBuy)
    {
        if(canBuy)
        {
            InputField.GetComponent<SelectInputField>().AddTextReformat("Upgrade Complete", false);
        }
        else
        {
            InputField.GetComponent<SelectInputField>().AddTextReformat("Error: Not enough bits", false);
        }
        
    }

    public void showDescription(string upgradeDescription)
    {
        InputField.GetComponent<SelectInputField>().AddTextReformat(upgradeDescription, false);
    }


    public void unknownCommand()
    {
        InputField.GetComponent<SelectInputField>().AddTextReformat("Error: Unknown Command", false);
    }

    public void exitShop()
    {
        InputField.GetComponent<SelectInputField>().AddTextReformat("Error: Please exit the shop first by typing 'back'", false);
    }

}
