﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonPress : MonoBehaviour {
    public GameObject operatorObject;
    protected OperatorScript fs;
	// Use this for initialization
	void Start () {
        fs = operatorObject.GetComponent<OperatorScript>();
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
        bool n = fs.DoOp(GameManager.instance.currentEquation.GetComponent<Equation>());
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
