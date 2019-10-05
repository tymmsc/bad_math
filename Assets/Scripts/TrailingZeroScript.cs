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

    public override bool DoOp(Equation inputEq)
    {
        //the new strings are the old strings with 0s at the end
        string newRight = inputEq.rightSide + "0";
        string newLeft = inputEq.leftSide + "0" ;

        
        inputEq.leftSide = newLeft;
        inputEq.rightSide = newRight;
        return true;

        //left side = right side
        //for each chara
    }
}
