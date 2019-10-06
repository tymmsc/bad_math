using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //the new strings are the old strings with 0s at the end
        if(side == "right") {
            string newRight = inputEq.rightSide + "0";
            string newLeft = inputEq.leftSide;
            inputEq.setEquation(newLeft, newRight);
        }
        else if(side == "left") {
            string newLeft = inputEq.leftSide + "0" ;
            string newRight = inputEq.rightSide;
            inputEq.setEquation(newLeft, newRight);
        }
        else {
            string newRight = inputEq.rightSide + "0";
            string newLeft = inputEq.leftSide + "0" ;

            inputEq.setEquation(newLeft, newRight);
        }
        return true;
    }
}
