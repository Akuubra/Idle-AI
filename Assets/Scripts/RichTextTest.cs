using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RichTextTest : MonoBehaviour {

    public Text text;
    private Text textComponent;

	// Use this for initialization
	void Start () {
        textComponent = text.GetComponent<Text>();//.supportRichText = true;
        //textComponent.supportRichText = true;
        
        //text.GetComponent<Text>().text = 
    }
    

    // Update is called once per frame
    void Update () {
        textComponent.text = "<color=blue>Test jgldflgkld dsflkgldsfg jsdglsdkf gjldsj lgdflgj dsjlkdsgkldsflkgdsfljlkdfs lkg jdlksfj lksdfjgjkdglkdfj  </color>";
    }
}
