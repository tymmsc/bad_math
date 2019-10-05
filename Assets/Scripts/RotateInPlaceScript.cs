using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlaceScript : OperatorScript
{
    public Dictionary<string, string> mapping90 = new Dictionary<string, string>() {
        { "0", "0" },
        { "1","-" },
        {"2", null },
        {"3", null },
        {"4", null },
        {"5", null },
        {"6", null },
        {"7", null },
        {"8", "∞" },
        {"9",null }
    };
    public Dictionary<string, string> mapping180 = new Dictionary<string, string>() {
        { "0", "0" },
        { "1","1" },
        {"2", null },
        {"3", null },
        {"4", null },
        {"5", null },
        {"6", "9" },
        {"7", null },
        {"8", "8" },
        {"9","6" }
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        string newRight = "";
        string newLeft = "";
     
        for (int i =0; i<inputEq.leftSide.Length; i++)
        {
            string toRotate = inputEq.leftSide.Substring(i, 1);
            string rotated = mapping180[toRotate];
            if (null == rotated)
            {
                return false;
            }
            newLeft = newLeft + rotated;
        }
        for (int i =0; i<inputEq.rightSide.Length; i++)
        {
            string toRotate = inputEq.rightSide.Substring(i, 1);
            string rotated = mapping180[toRotate];
            if (null == rotated)
            {
                return false;
            }
            newRight = newRight + rotated;
        }
        inputEq.leftSide = newLeft;
        inputEq.rightSide = newRight;
        return true;
    }
}
