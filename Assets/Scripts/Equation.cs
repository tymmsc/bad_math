using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equation : MonoBehaviour {

    public string leftSide; 
    public string rightSide;
    
	// Use this for initialization
	void Start () {

        GetComponent<Text>().text = leftSide + "=" + rightSide;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = leftSide + "=" + rightSide;
    }
}
