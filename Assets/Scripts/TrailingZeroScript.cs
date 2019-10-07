using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script actually adds any leading digit you want. 
public class TrailingZeroScript : OperatorScript
{



    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        string side;
        if (options!=null && options.ContainsKey("side"))
        {
            side = options["side"];
        }
        else
        {
            side = null;
        }
        string digit = "0";
        if(options!=null && options.ContainsKey("number")){
            digit = options["number"];
        }
        //the new strings are the old strings with 0s at the end
        if(side == "right") {
            string newRight = digit + inputEq.rightSide;
            string newLeft = inputEq.leftSide;
            inputEq.setEquation(newLeft, newRight);
        }
        else if(side == "left") {
            string newLeft = digit + inputEq.leftSide ;
            string newRight = inputEq.rightSide;
            inputEq.setEquation(newLeft, newRight);
        }
        else {
            string newRight = digit + inputEq.rightSide;
            string newLeft = digit + inputEq.leftSide;

            inputEq.setEquation(newLeft, newRight);
        }
        return true;
    }
}
