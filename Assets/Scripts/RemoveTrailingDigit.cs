using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrailingDigit : OperatorScript
{
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
        int rightLength = inputEq.rightSide.Length;
        int leftLength = inputEq.leftSide.Length;
        if(inputEq.rightSide[rightLength -1] == inputEq.leftSide[leftLength-1]  &&
            rightLength > 1 && leftLength > 1)
        {
            newRight = inputEq.rightSide.Substring(0,rightLength -1);
            newLeft = inputEq.leftSide.Substring(0, leftLength -1);
            inputEq.setEquation(newLeft, newRight);
            return true;
        }
        return false;


 

        //left side = right side
        //for each chara
    }
}
