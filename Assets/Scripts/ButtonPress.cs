﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to each button and holds the object 
//holding the Operator Script for that button (hacky but I'm
//not sure how else to do it)

    //It also houses the basic button functions like clicking and unclicking,
    //Later mouse hovering, etc

public class ButtonPress : MonoBehaviour {
    public GameObject operatorObject;
    protected OperatorScript fs;
    public Dictionary<string, string> options;
    public string side;
    public string location;
    public string number;
    public Sprite spriteImage;
    Sprite spriteOver;
	// Use this for initialization
	void Start () {
        fs = operatorObject.GetComponent<OperatorScript>();
        options = new Dictionary<string, string>();
        if (side!="")
        {
            options["side"] = side;
        }
        if (location != "")
        {
            options["location"] = location; 
        }
        if (number != "")
        {
            options["number"] = number;
        }
        spriteOver = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = spriteImage;
        


    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = spriteOver;
    }
    private void OnMouseExit()
    {
        GetComponent < SpriteRenderer>().sprite = spriteImage;
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
        Equation currentEquation = new Equation();
        currentEquation.leftSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().leftSide;
        currentEquation.rightSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().rightSide;
        bool n = fs.DoOp(GameManager.instance.currentEquationObj.GetComponent<Equation>(), options);
        //if it's not possible here, turn it red
        if (false == n)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .0f, .0f);
        }
        else
        {

            //if it is successful turn it gray, and update the equation panels 
            GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
            GameManager.instance.pastEquations.GetComponent<EquationArray>().PushEquation(currentEquation);
        }
        //Call some other function to do somethng, maybe
        
    }
    private void OnMouseUp()
    {
        //turn it white again
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }
    
        
    
}
