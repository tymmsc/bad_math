using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLeadingDigits : OperatorScript{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        string newRight = "";
            string newLeft = "";
        //The new strings are the old ones with one leading zero removed 
        
        if(inputEq.rightSide[0] == inputEq.leftSide[0]  &&
            inputEq.rightSide.Length > 1 && inputEq.leftSide.Length > 1)
        {
            newRight = inputEq.rightSide.Substring(1);
            newLeft = inputEq.leftSide.Substring(1);
            inputEq.setEquation(newLeft, newRight);
            return true;
        }
        return false;


 

        //left side = right side
        //for each chara
    }
}
