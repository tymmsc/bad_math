using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to each button and holds the object 
//holding the Operator Script for that button (hacky but I'm
//not sure how else to do it)

    //It also houses the basic button functions like clicking and unclicking,
    //Later mouse hovering, etc

public class ButtonPress : MonoBehaviour {
    public GameObject operatorObject;
    public string side;
    protected Dictionary<string, string> options;
    protected OperatorScript fs;
	// Use this for initialization
	void Start () {
        fs = operatorObject.GetComponent<OperatorScript>();
        options = new Dictionary<string, string>() {
            {"side", side}
        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseOver()
    {
        //turn it some color
    }

    private void OnMouseDown()
    {

        bool n = fs.DoOp(GameManager.instance.currentEquation.GetComponent<Equation>(), options);
        if (false == n)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .0f, .0f);
        }
        else
        {
            //turn it gray
            GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
        }
        //Call some other function to do somethng, maybe
        
    }
    private void OnMouseUp()
    {
        //turn it white again
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }
    
        
    
}
